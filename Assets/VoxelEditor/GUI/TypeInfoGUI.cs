﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeInfoGUI : GUIPanel
{
    public PropertiesObjectType type;

    public override Rect GetRect(Rect safeRect, Rect screenRect)
    {
        return GUIUtils.HorizCenterRect(safeRect.center.x,
            safeRect.yMin + safeRect.height * .2f, 960, 0);
    }

    public override void WindowGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(type.icon, GUILayout.ExpandWidth(false));
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label(type.fullName, GUIStyleSet.instance.labelTitle);
        if (GUILayout.Button("Done", GUILayout.ExpandWidth(false)))
            Destroy(this);
        GUILayout.EndHorizontal();
        GUILayout.Label(type.description, GUIUtils.LABEL_WORD_WRAPPED.Value);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.Label("<i>" + type.longDescription + "</i>", GUIUtils.LABEL_WORD_WRAPPED.Value);
    }
}