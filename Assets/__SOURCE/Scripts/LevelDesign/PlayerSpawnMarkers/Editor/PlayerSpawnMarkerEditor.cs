using UnityEditor;
using UnityEngine;

namespace LevelDesign.PlayerSpawnMarkers.Editor
{
  [CustomEditor(typeof(PlayerSpawnMarker))]
  public class PlayerSpawnMarkerEditor : UnityEditor.Editor
  {
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void RenderCustomGizmo(PlayerSpawnMarker point, GizmoType gizmo)
    {
      CircleGizmo(point.transform, .4f, Color.green);

      ShowInfo(point);
    }

    private static void ShowInfo(PlayerSpawnMarker point)
    {
      GUIStyle style = GUIStyle();

      Vector3 position = point.transform.position;
      position.y += 2f;

      GUIContent gUIContent = new GUIContent(point.transform.name);

      Handles.Label(position, gUIContent, style);
    }

    private static GUIStyle GUIStyle()
    {
      GUIStyle style = new GUIStyle();

      style.normal.textColor = Color.white;
      style.alignment = TextAnchor.MiddleCenter;
      style.fontSize = 8;
      style.fontStyle = FontStyle.Normal;
      style.fixedHeight = 120;
      style.fixedWidth = 40;
      style.imagePosition = ImagePosition.ImageAbove;

      return style;
    }

    private static void CircleGizmo(Transform transform, float radius, Color color)
    {
      Gizmos.color = color;
      Vector3 position = transform.position;
      Gizmos.DrawSphere(position, radius);
    }
  }
}