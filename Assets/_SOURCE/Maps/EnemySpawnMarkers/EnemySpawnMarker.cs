using System.Collections;
using System.Collections.Generic;
using _SOURCE.Gameplay.Characters.Enemies;
using UnityEngine;

public class EnemySpawnMarker : MonoBehaviour
{
  [field: SerializeField] public EnemyId EnemyId { get; private set; }
  [field: SerializeField] public int Count { get; private set; }
}