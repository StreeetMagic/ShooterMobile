﻿//////////////////////////////////////////////////////
// MK Toon Editor Color RGB Drawer        			//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2021 All rights reserved.            //
//////////////////////////////////////////////////////

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace UnityAssetsTools._MK.MKToon.Editor.Helper
{
    internal class MKToonColorHDRRGBDrawer : MaterialPropertyDrawer
    {
        public MKToonColorHDRRGBDrawer(GUIContent ui) : base(ui) {}
        public MKToonColorHDRRGBDrawer() : base(GUIContent.none) {}

        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
        {
            EditorGUI.showMixedValue = prop.hasMixedValue;
            Color color = prop.colorValue;
            EditorGUI.BeginChangeCheck();

            color = EditorGUI.ColorField(position, new GUIContent(label), color, true, false, true);

            if (EditorGUI.EndChangeCheck())
            {
                prop.colorValue = color;
            }
            EditorGUI.showMixedValue = false;
        }
    }
}
#endif