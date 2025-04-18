﻿using System.Collections;
using UnityEngine;

public class HUDCounter {
    private readonly string text;
    private int lastValue = -1;
    private float changeTime = -10f;
    private bool negativeChange;
    private bool hasUpdated = false;

    public HUDCounter(string text) {
        this.text = text;
    }

    public void Update(int value) {
        if (hasUpdated && lastValue != value) {
            changeTime = Time.time;
            negativeChange = value < lastValue;
        }
        lastValue = value;
        hasUpdated = true;
        Display();
    }

    public void Display() {
        if (!hasUpdated) {
            return;
        }
        Color baseColor = GUI.color;
        if (Time.time - changeTime < 1.0) {
            if (negativeChange) {
                GUI.color *= Color.Lerp(Color.red, Color.white, Time.time - changeTime);
            } else {
                GUI.color *= Color.Lerp(Color.green, Color.white, Time.time - changeTime);
            }
        }
        ActionBarGUI.ActionBarLabel(text + lastValue);
        GUI.color = baseColor;
    }
}

// based on MenuOverflowGUI
public class PauseGUI : GUIPanel {
    public GameLoad gameLoad;
    private OverflowMenuGUI pauseMenu;
    private FadeGUI fade;

    private bool paused = false;
    private bool wasAlive = false;

    private HUDCounter healthCounter;
    private HUDCounter scoreCounter;

    public override Rect GetRect(Rect safeRect, Rect screenRect) =>
        new Rect(safeRect.xMin, safeRect.yMin, safeRect.width, 0);

    public override GUIStyle GetStyle() => GUIStyle.none;

    void Start() {
        GUIPanel.topPanel = this;
        healthCounter = new HUDCounter(StringSet.HealthCounterPrefix);
        scoreCounter = new HUDCounter(StringSet.ScoreCounterPrefix);
    }

    public override void OnEnable() {
        holdOpen = true;
        stealFocus = false;
        base.OnEnable();
    }

    public override void WindowGUI() {
        if (pauseMenu != null) {
            pauseMenu.BringToFront();
        }

        GUILayout.BeginHorizontal();

        PlayerComponent player = PlayerComponent.instance;
        if (player != null) {
            wasAlive = true;

            healthCounter.Update((int)player.health);
            if (player.hasScore) {
                scoreCounter.Update(player.score);
            }
        } else if (wasAlive) {
            ActionBarGUI.ActionBarLabel(StringSet.YouDied);
            scoreCounter.Display();
        }

        //ActionBarGUI.ActionBarLabel((int)(1.0f / Time.smoothDeltaTime) + " FPS");

        GUILayout.FlexibleSpace();
        if (ActionBarGUI.ActionBarButton(IconSet.pause)) {
            PauseGame();
        }
        GUILayout.EndHorizontal();
    }

    void Update() {
        if (Input.GetButtonUp("Cancel") && !paused) {
            StartCoroutine(PauseNextFrame());
        } else if (Input.GetMouseButtonDown(0) && !paused
                && PanelContainingPoint(Input.mousePosition) == null) {
            GameInput.LockCursor();
        }

        if (paused && pauseMenu == null) {
            paused = false;
            Time.timeScale = 1;
            AudioListener.pause = false;
            Destroy(fade);
        }

        if (Input.GetButtonDown("Pause")) {
            if (paused) {
                Destroy(pauseMenu);
                GameInput.LockCursor();
            } else {
                PauseGame();
            }
        }

        GameInput.FixCursorLock();
    }

    private IEnumerator PauseNextFrame() {
        yield return null;
        if (!paused) {
            PauseGame();
        }
    }

    private void PauseGame() {
        GameInput.UnlockCursor();
        Time.timeScale = 0;
        AudioListener.pause = true;
        paused = true;

        pauseMenu = gameObject.AddComponent<OverflowMenuGUI>();
        pauseMenu.items = new OverflowMenuGUI.MenuItem[] {
            new OverflowMenuGUI.MenuItem(StringSet.ResumeGame, IconSet.play,
                () => {}), // menu will close
            new OverflowMenuGUI.MenuItem(StringSet.RestartGame, IconSet.restart,
                () => { gameLoad.Close(Scenes.GAME); }),
#if !UNITY_WEBGL
            new OverflowMenuGUI.MenuItem(StringSet.OpenEditor, IconSet.editor,
                () => { gameLoad.Close(Scenes.EDITOR); }),
#endif
            new OverflowMenuGUI.MenuItem(StringSet.CloseGame, IconSet.x,
                () => { gameLoad.Close(Scenes.MENU); }),
        };

        fade = gameObject.AddComponent<FadeGUI>();
    }
}