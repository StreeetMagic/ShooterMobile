using UnityEditor;
using UnityEngine;

namespace _SOURCE.Maps.EnemySpawnPoints.Editor
{
  [CustomEditor(typeof(EnemySpawnMarker))]
  public class EnemySpawnMarkerEditor : UnityEditor.Editor
  {
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void RenderCustomGizmo(EnemySpawnMarker marker, GizmoType gizmo)
    {
      CircleGizmo(marker.transform, .4f, Color.red);

      var text = 
        "Enemy spawner \n" +
        marker.EnemyId + " type \n" + 
        marker.Count + " enemies count";
      
      ShowInfo(marker, text);
    }

    private static void ShowInfo(EnemySpawnMarker marker, string text)
    {
      GUIStyle style = GUIStyle();

      Vector3 position = marker.transform.position;
      position.y += 2f;

      GUIContent gUIContent = new GUIContent(text);

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