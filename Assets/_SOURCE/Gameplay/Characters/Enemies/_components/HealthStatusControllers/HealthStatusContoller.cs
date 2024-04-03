using System.Collections;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class HealthStatusController
  {
    private readonly Enemy _enemy;
    private readonly EnemyHealth _enemyHealth;
    private readonly EnemyReturnToSpawn _returnToSpawn;

    private HealthStatusController(EnemyHealth enemyHealth,
      Enemy enemy, EnemyReturnToSpawn enemyReturnToSpawn)
    {
      _enemyHealth = enemyHealth;
      _enemy = enemy;
      _returnToSpawn = enemyReturnToSpawn;

      _enemyHealth.Damaged += OnDamaged;
    }

    private EnemyConfig Config => _enemy.Config;
    public bool IsHit { get; set; }
    private float RunTime => 5;

    private void OnDamaged(int damage)
    {
      if (_returnToSpawn.IsReturn)
        return;

      IsHit = true;
    }
  }
}