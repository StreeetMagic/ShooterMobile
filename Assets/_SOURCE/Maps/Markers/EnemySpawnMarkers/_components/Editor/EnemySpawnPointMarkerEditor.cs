using UnityEditor;
using UnityEngine;

namespace Maps.EnemySpawnMarkers.Editor
{
  public class EnemySpawnPointMarkerEditor : UnityEditor.Editor
  {
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void RenderCustomGizmo(EnemySpawnPointMarker marker, GizmoType gizmo)
    {
      CircleGizmo(marker.transform, .4f, Color.yellow);
    }

    private static void CircleGizmo(Transform transform, float radius, Color color)
    {
      Gizmos.color = color;
      Vector3 position = transform.position;
      Gizmos.DrawSphere(position, radius);
    }
  }
}