using UnityEditor;
using UnityEngine;
using UserInterface.HeadsUpDisplays.MobileJoysticks.ImportedJoystickPack.FloatingJoysticks.Scripts.Joysticks;

namespace UserInterface.HeadsUpDisplays.MobileJoysticks.ImportedJoystickPack.FloatingJoysticks.Scripts.Editor
{
    [CustomEditor(typeof(FloatingJoystick))]
    public class FloatingJoystickEditor : JoystickEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Background != null)
            {
                RectTransform backgroundRect = (RectTransform)Background.objectReferenceValue;
                backgroundRect.anchorMax = Vector2.zero;
                backgroundRect.anchorMin = Vector2.zero;
                backgroundRect.pivot = Center;
            }
        }
    }
}