﻿//////////////////////////////////////////////////////
// MK Toon Material Upgrader        			    //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2021 All rights reserved.            //
//////////////////////////////////////////////////////

using System.Collections.Generic;
using UnityAssetsTools._MK.MKToon.Editor.Helper;
using UnityAssetsTools._MK.MKToon.Scripts;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace UnityAssetsTools._MK.MKToon.Editor
{
    public class MaterialUpgrader : EditorWindow
    {
        [MenuItem("Window/MK/Toon/Material Upgrader")]
        static void Init()
        {
            MaterialUpgrader window = (MaterialUpgrader)EditorWindow.GetWindow<MaterialUpgrader>(true, "MK Toon Material Upgrader", true);
            window.maxSize = new Vector2(360, 435);
            window.minSize = new Vector2(360, 435);
            window.Show();
        }

        private RenderPipelineUpgrade _targetRenderPipeline;

        private string[] _guids;
        private List<Material> _mkToonMaterials = new List<Material>();

        private void OnGUI()
        {
            if(GUILayout.Button("Scan Project for MK Toon Materials"))
            {
                _guids = AssetDatabase.FindAssets("t:material", null);
                _mkToonMaterials = new List<Material>();
                for(int i = 0; i < _guids.Length; i++)
                {
                    Material m =  AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(_guids[i]), typeof(Material)) as Material;
                    if(m != null)
                    {
                        if(m.shader.name.Contains("MK/Toon/"))
                        {
                            _mkToonMaterials.Add(m);
                        }
                    }
                }
            }

            EditorGUILayout.LabelField("Materials that are using a MK Toon Shader: " + _mkToonMaterials.Count);

            if(_mkToonMaterials.Count > 0)
            {
                EditorHelper.Divider();
                _targetRenderPipeline = (RenderPipelineUpgrade) EditorGUILayout.EnumPopup("Render Pipeline", _targetRenderPipeline);
                if(GUILayout.Button("Upgrade All MK Toon Project Materials"))
                {
                    EditorUtility.DisplayProgressBar("MK Toon Material Upgrader", "Upgrading Materials...", 0.5f);
                    for(int i = 0; i < _mkToonMaterials.Count; i++)
                    {
                        string shaderName = _mkToonMaterials[i].shader.name;
                        if(_targetRenderPipeline == RenderPipelineUpgrade.Universal)
                            shaderName = shaderName.Replace("/Built-in/", "/URP/");
                        else
                           shaderName = shaderName.Replace("/Built-in/", "/LWRP/");
                        
                        Shader shader = Shader.Find(shaderName);
                        if(shader != null)
                        {
                            _mkToonMaterials[i].shader = shader;
                            //Somehow on urp the upgrade for refractive materials requires to reset the surface
                            Properties.surface.SetValue(_mkToonMaterials[i], Properties.surface.GetValue(_mkToonMaterials[i]));
                            if(!shader.name.Contains("Unlit"))
                                Properties.receiveShadows.SetValue(_mkToonMaterials[i], Properties.receiveShadows.GetValue(_mkToonMaterials[i]));
                        }
                    }
                    AssetDatabase.Refresh();
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    EditorUtility.ClearProgressBar();
                }
            }
        }
    }
}
#endif