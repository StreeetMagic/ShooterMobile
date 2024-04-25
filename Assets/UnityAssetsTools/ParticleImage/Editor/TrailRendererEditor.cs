using UnityAssetsTools.ParticleImage.Editor.Utility;
using UnityAssetsTools.ParticleImage.Runtime;
using UnityEditor;
using UnityEngine;

namespace UnityAssetsTools.ParticleImage.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ParticleTrailRenderer))]
    public class TrailRendererEditor : UnityEditor.Editor
    {
        void Awake()
        {
            MonoScript.FromMonoBehaviour(target as ParticleTrailRenderer).SetIcon(Resources.Load<Texture2D>("TrailIcon"));
        }
        
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Particle Image trail renderer.", MessageType.Info);
        }
    }
}

