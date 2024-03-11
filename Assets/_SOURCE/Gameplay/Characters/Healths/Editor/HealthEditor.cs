using UnityEditor;
using UnityEngine;

namespace Gameplay.Characters.Healths.Editor
{
  [CustomEditor(typeof(Health))]
  public class HealthEditor : UnityEditor.Editor
  {
    // [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    // public static void RenderCustomGizmo(Health health, GizmoType gizmo)
    // {
    //   string text = health.Current + " / " + health.Initial;
    //
    //   ShowInfo(health, text);
    // }
    //
    // private static void ShowInfo(Health health, string text)
    // {
    //   GUIStyle style = new GUIStyle();
    //   
    //   style.normal.textColor = Color.white;
    //   style.alignment = TextAnchor.MiddleCenter;
    //   style.fontSize = 20;
    //   style.fontStyle = FontStyle.Normal;
    //   style.fixedHeight = 120;
    //   style.fixedWidth = 40;
    //   style.imagePosition = ImagePosition.ImageAbove;
    //
    //   Vector3 position = health.transform.position;
    //   position.y += 2f;
    //
    //   GUIContent gUIContent = new GUIContent(text);
    //
    //   Handles.Label(position, gUIContent, style);
    // }
  }
}