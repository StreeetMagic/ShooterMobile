using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Map : MonoBehaviour
{
  [field: SerializeField] public PlayerSpawnPoint PlayerSpawnPoint { get; private set; }

  [Button]
  private void Resolve()
  {
    PlayerSpawnPoint = GetComponentInChildren<PlayerSpawnPoint>();
  }
}