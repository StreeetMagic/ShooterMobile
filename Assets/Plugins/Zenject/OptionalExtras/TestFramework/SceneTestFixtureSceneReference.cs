#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace Zenject.OptionalExtras.TestFramework
{
    public class SceneTestFixtureSceneReference : ScriptableObject
    {
        public SceneAsset Scene;
    }
}

#endif
