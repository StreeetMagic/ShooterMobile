using UnityEngine;

namespace Maps.Markers.SubQuestMarkers.BombDefuse
{
  public class BombDefuseMarker : MonoBehaviour
  {
    [Tooltip("Время повторного появления этой же бомбы после дефьюза")]
    public float RespawnTime = 5;
  }
}