using Configs.Resources.EnemyConfigs.Scripts;
using UnityEngine;

namespace Maps.EnemySpawnMarkers
{
  public class EnemySpawnMarker : MonoBehaviour
  {
    public EnemyId EnemyId;
    public int Count;
    public int RespawnTime = 15;
    public Transform Container;
  }
}