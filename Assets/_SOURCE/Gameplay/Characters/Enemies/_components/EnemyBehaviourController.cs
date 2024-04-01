using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyBehaviourController : MonoBehaviour
  {
    private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;
    
    [Inject]
    public void Construct(EnemyMoverToSpawnPoint enemyMoverToSpawnPoint)
    {
      _enemyMoverToSpawnPoint = enemyMoverToSpawnPoint;
    }

    private void Start()
    {
      _enemyMoverToSpawnPoint.enabled = false;
    }
  }
}