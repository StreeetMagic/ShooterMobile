using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyHealer : MonoBehaviour
  {
    private EnemyHealth _enemyHealth;
    private HealthStatusController _healthStatusController;
    private Enemy _enemy;

    private float _heal;
    private float _timer;

    [Inject]
    private void Construct(EnemyHealth enemyHealth, HealthStatusController healthStatusController, Enemy enemy)
    {
      _enemyHealth = enemyHealth;
      _healthStatusController = healthStatusController;
      _enemy = enemy;
    }

    private float HealMultiplier => EnemyConfig.HealMultiplier;
    private EnemyConfig EnemyConfig => _enemy.Config;

    private void OnEnable()
    {
      _heal = 0;
      _timer = 0;
    }

    private void Update()
    {
      if (_enemyHealth.IsDead)
        return;

      _timer += Time.deltaTime;

      if (_healthStatusController.IsHit)
      {
        _timer = 0;
        return;
      }

      if (_enemyHealth.IsFull)
        return;

      float healAmount = (float)EnemyConfig.InitialHealth;

      _heal += healAmount * Time.deltaTime * HealMultiplier;

      if (_heal >= 1)
      {
        if (_timer >= _enemy.Config.RunTime)
        {
          _enemyHealth.Current.Value++;
          _heal = 0;
        }
      }
    }
  }
}