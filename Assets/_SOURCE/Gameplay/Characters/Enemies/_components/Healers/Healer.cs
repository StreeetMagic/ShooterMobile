using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class Healer : MonoBehaviour
  {
    private Health _health;
    private HealthStatusController _healthStatusController;
    private EnemyConfig _enemyConfig;

    private float _heal;

    public void Init(Health health, HealthStatusController healthStatusController, EnemyConfig enemyConfig)
    {
      _health = health;
      _healthStatusController = healthStatusController;
      _enemyConfig = enemyConfig;
    }
    
    public float HealMultiplier => _enemyConfig.HealMultiplier;
    
    private void Update()
    {
      if (_health.IsDead)
        return;

      if (_healthStatusController.IsHit)
        return;

      if (_health.IsFull)
        return;

      float healAmount = (float)_enemyConfig.InitialHealth;

      _heal += healAmount * Time.deltaTime * HealMultiplier;

      if (_heal >= 1)
      {
        _health.Current.Value++;
        _heal = 0;
      }
    }
  }
}