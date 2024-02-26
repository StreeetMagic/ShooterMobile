using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class Map : MonoBehaviour
{
  [field: SerializeField] public PlayerSpawnMarker PlayerSpawnPoint { get; private set; }
  [SerializeField] private List<EnemySpawnMarker> _enemySpawnPoints;

  public List<EnemySpawnMarker> EnemySpawnPoints => _enemySpawnPoints.ToList();

  [Button]
  private void Resolve()
  {
    PlayerSpawnPoint = GetComponentInChildren<PlayerSpawnMarker>();

    _enemySpawnPoints =
      GetComponentsInChildren<EnemySpawnMarker>()
        .ToList();
  }
}