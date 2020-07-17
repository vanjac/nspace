﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BevelActionBarGUI : ActionBarGUI
{
    private BevelGUI bevelGUI;

    public override void OnEnable()
    {
        base.OnEnable();
        stealFocus = true;
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void Start()
    {
        base.Start();
        bevelGUI = gameObject.AddComponent<BevelGUI>();
        bevelGUI.voxelArray = voxelArray;
        bevelGUI.touchListener = touchListener;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Destroy(bevelGUI);
    }

    public override void WindowGUI()
    {
        // clear substance highlight while properties panel is disabled
        EntityReferencePropertyManager.Reset(null);

        GUILayout.BeginHorizontal();
        SelectionGUI();
        GUILayout.FlexibleSpace();

        Vector3 selectionSize = voxelArray.selectionBounds.size;
        if (selectionSize == Vector3.zero)
            ActionBarLabel("Select edges to bevel...");
        else
            ActionBarLabel(SelectionString(selectionSize));

        GUILayout.FlexibleSpace();
        TutorialGUI.TutorialHighlight("bevel done");
        if (HighlightedActionBarButton(GUIIconSet.instance.done))
            Destroy(this);
        TutorialGUI.ClearHighlight();
        GUILayout.EndHorizontal();
    }
}


public class BevelGUI : LeftPanelGUI
{
    public VoxelArrayEditor voxelArray;
    public TouchListener touchListener;

    private Voxel.BevelType bevelType;

    public override Rect GetRect(Rect safeRect, Rect screenRect)
    {
        return new Rect(safeRect.xMin, safeRect.yMin, 540, 0);
    }

    public override void OnEnable()
    {
        holdOpen = true;
        stealFocus = false;
        base.OnEnable();
        EnableEdgeMode();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        touchListener.selectType = VoxelElement.FACES;
        voxelArray.ClearStoredSelection();
        voxelArray.ClearSelection();
    }

    public override void Start()
    {
        base.Start();
        EnableEdgeMode();
    }

    private void EnableEdgeMode()
    {
        if (touchListener != null)
            touchListener.selectType = VoxelElement.EDGES;
        if (voxelArray != null)
        {
            voxelArray.ClearStoredSelection();
            voxelArray.ClearSelection();
        }
    }

    public override void WindowGUI()
    {
        if (voxelArray.selectionChanged)
        {
            voxelArray.selectionChanged = false;
            bevelType = voxelArray.GetSelectedBevelType();
        }

        GUILayout.Label("Bevel:", GUIStyleSet.instance.labelTitle);

        if (!voxelArray.SomethingIsSelected())
        {
            GUILayout.Label("(none selected)");
            return;
        }

        TutorialGUI.TutorialHighlight("bevel shape");
        GUILayout.Label("Shape:");
        var newBevelType = (Voxel.BevelType)GUILayout.SelectionGrid((int)bevelType,
            new Texture[] {
                GUIIconSet.instance.no,
                GUIIconSet.instance.bevelIcons.flat,
                GUIIconSet.instance.bevelIcons.curve,
                GUIIconSet.instance.bevelIcons.square,
                GUIIconSet.instance.bevelIcons.stair2,
                GUIIconSet.instance.bevelIcons.stair4 },
            3, GUIStyleSet.instance.buttonTab);
        TutorialGUI.ClearHighlight();

        if (newBevelType != bevelType)
        {
            bevelType = newBevelType;
            voxelArray.BevelSelectedEdges(bevelType);
        }
    }
}
