using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class Healer : MonoBehaviour
  {
    private EnemyHealth _enemyHealth;
    private HealthStatusController _healthStatusController;
    private Enemy _enemy;

    private float _heal;

    [Inject]
    private void Construct(EnemyHealth enemyHealth, HealthStatusController healthStatusController, Enemy enemy)
    {
      _enemyHealth = enemyHealth;
      _healthStatusController = healthStatusController;
      _enemy = enemy;
    }

    private float HealMultiplier => EnemyConfig.HealMultiplier;
    private EnemyConfig EnemyConfig => _enemy.Config;

    private void Update()
    {
      if (_enemyHealth.IsDead)
        return;

      if (_healthStatusController.IsHit)
        return;

      if (_enemyHealth.IsFull)
        return;

      float healAmount = (float)EnemyConfig.InitialHealth;

      _heal += healAmount * Time.deltaTime * HealMultiplier;

      if (_heal >= 1)
      {
        _enemyHealth.Current.Value++;
        _heal = 0;
      }
    }
  }
}