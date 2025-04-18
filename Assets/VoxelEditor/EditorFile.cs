﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorFile : MonoBehaviour {
    public static EditorFile instance;
    public LoadingGUI loadingGUI;
    public List<MonoBehaviour> enableOnLoad;

    public VoxelArrayEditor voxelArray;
    public Transform cameraPivot;
    public TouchListener touchListener;
    public Transform cameraTransform;
    public Camera thumbnailCamera;

    // importWorldHandler MUST dispose stream and call ShareMap.ClearFileWaitingToImport() when finished
    public Action<System.IO.Stream> importWorldHandler;

    void Start() {
        instance = this;
    }

    public void Load() {
        StartCoroutine(LoadCoroutine());
    }

    private IEnumerator LoadCoroutine() {
        yield return AssetPack.LoadAsync(); // always waits at least 1 frame
        var guiGameObject = loadingGUI.gameObject;

        List<string> warnings;
        try {
            warnings = ReadWorldFile.Read(SelectedWorld.GetLoadStream(),
                cameraPivot, voxelArray, true);
        } catch (MapReadException e) {
            var dialog = guiGameObject.AddComponent<DialogGUI>();
            dialog.message = e.FullMessage;
            dialog.yesButtonText = GUIPanel.StringSet.Close;
            dialog.yesButtonHandler = () => {
                voxelArray.unsavedChanges = false;
                Close();
            };
            Destroy(loadingGUI);
            Debug.LogError(e);
            yield break;
        }
        // reading the file creates new voxels which sets the unsavedChanges flag
        // and clears existing voxels which sets the selectionChanged flag
        voxelArray.unsavedChanges = false;
        voxelArray.selectionChanged = false;

        Destroy(loadingGUI);
        foreach (MonoBehaviour b in enableOnLoad) {
            b.enabled = true;
        }

        if (PlayerPrefs.HasKey("last_editScene_version")) {
            string lastVerStr = PlayerPrefs.GetString("last_editScene_version");
            if (ParseAppVersion(lastVerStr, out var lastVersion)) {
                if (lastVersion < new Version(1, 4, 0)) {
                    LargeMessageGUI.ShowLargeMessageDialog(guiGameObject,
                        GUIPanel.StringSet.UpdateMessage_1_4_0);
                }
            } else {
                Debug.LogError("Unable to parse version: " + lastVerStr);
            }
        }
        PlayerPrefs.SetString("last_editScene_version", Application.version);

        // avoids a bug where two dialogs created on the same frame will put the unfocused one on top
        // for some reason it's necessary to wait two frames
        yield return null;
        yield return null;

        if (SelectedWorld.IsUserCreatedWorld() && !File.Exists(SelectedWorld.GetThumbnailPath())) {
            Debug.Log("Creating new thumbnail");
            SaveThumbnail();
        }

        if (warnings.Count > 0) {
            string message = GUIPanel.StringSet.WorldWarningsHeader + "\n\n  •  " +
                string.Join("\n  •  ", warnings.ToArray());
            LargeMessageGUI.ShowLargeMessageDialog(guiGameObject, message);
        }
    }

    private bool ParseAppVersion(string str, out Version version) {
        if (str.EndsWith("b")) {
            str = str.Substring(0, str.Length - 1); // 1.3.4b, 1.3.6b
        }
        str = str.Split('-')[0]; // remove pre-release suffix
        return Version.TryParse(str, out version);
    }

    public bool Save(bool allowPopups = true) {
        if (!voxelArray.unsavedChanges) {
            Debug.unityLogger.Log("EditorFile", "No unsaved changes");
            return true;
        }
        if (voxelArray.IsEmpty()) {
            Debug.Log("World is empty! File will not be written.");
            return true;
        }
        string savePath = SelectedWorld.GetSavePath();
        try {
            if (System.IO.File.Exists(savePath)) {
                MessagePackWorldWriter.Write(WorldFiles.GetTempPath(),
                    cameraPivot, voxelArray);
                WorldFiles.RestoreTempFile(savePath);
            } else {
                MessagePackWorldWriter.Write(savePath, cameraPivot, voxelArray);
            }
            voxelArray.unsavedChanges = false;
            SaveThumbnail();
            return true;
        } catch (Exception e) {
            if (allowPopups) {
                string message = GUIPanel.StringSet.UnknownSaveError + e.ToString();
                var dialog = LargeMessageGUI.ShowLargeMessageDialog(GUIPanel.GuiGameObject, message);
                dialog.closeHandler = () => SceneManager.LoadScene(Scenes.MENU);
                voxelArray.unsavedChanges = false;
            }
            return false;
        }
    }

    private void SaveThumbnail() {
        thumbnailCamera.transform.position = cameraTransform.position;
        thumbnailCamera.transform.rotation = cameraTransform.rotation;

        var rt = thumbnailCamera.targetTexture;
        var prevRT = RenderTexture.active;
        RenderTexture.active = rt;

        thumbnailCamera.Render();
        var image = new Texture2D(rt.width, rt.height);
        image.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        image.Apply();

        RenderTexture.active = prevRT;

        var bytes = image.EncodeToJPG(90);
        Destroy(image);
        File.WriteAllBytes(SelectedWorld.GetThumbnailPath(), bytes);
    }

    public void Play() {
        Debug.unityLogger.Log("EditorFile", "Play");
        if (Save()) {
            SceneManager.LoadScene(Scenes.GAME);
        }
    }

    public void Close() {
        Debug.unityLogger.Log("EditorFile", "Close");
        if (Save()) {
            SceneManager.LoadScene(Scenes.MENU);
        }
    }

    public void Revert() {
        Debug.unityLogger.Log("EditorFile", "Revert");
        SceneManager.LoadScene(Scenes.EDITOR);
    }

    void OnEnable() {
        Debug.unityLogger.Log("EditorFile", "OnEnable()");
        Load();
    }

    void OnApplicationQuit() {
        Debug.unityLogger.Log("EditorFile", "OnApplicationQuit()");
        Save(allowPopups: false);
    }

    void OnApplicationPause(bool pauseStatus) {
        Debug.unityLogger.Log("EditorFile", "OnApplicationPause(" + pauseStatus + ")");
        if (pauseStatus) {
            Save(allowPopups: false);
        } else if (ShareMap.FileWaitingToImport()) {
            if (importWorldHandler == null) {
                if (Save()) {
                    SceneManager.LoadScene(Scenes.FILE_RECEIVE);
                }
            } else {
                System.IO.Stream stream = null;
                try {
                    stream = ShareMap.GetImportStream();
                    importWorldHandler(stream);
                } catch (Exception e) {
                    DialogGUI.ShowMessageDialog(GUIPanel.GuiGameObject,
                        GUIPanel.StringSet.UnknownReadError);
                    Debug.LogError(e);
                    stream?.Dispose();
                    ShareMap.ClearFileWaitingToImport();
                }
            }
        }
    }
}
