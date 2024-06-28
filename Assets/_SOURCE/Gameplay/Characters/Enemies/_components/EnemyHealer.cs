using Gameplay.Characters.Enemies.Configs;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyHealer
  {
    private readonly IHealth _enemyHealth;
    private readonly EnemyConfig _config;

    private float _heal;
    private float _timer;

    public EnemyHealer(IHealth enemyHealth, EnemyConfig config)
    {
      _enemyHealth = enemyHealth;
      _config = config;
    }

    private float HealMultiplier => _config.HealMultiplier;

    public void Heal()
    {
      if (_enemyHealth.Current.Value >= _enemyHealth.Initial)
        return;

      float healAmount = _config.InitialHealth;

      _heal += healAmount * Time.deltaTime * HealMultiplier;

      if (_heal >= 1)
      {
        _enemyHealth.Current.Value++;
        _heal = 0;
      }
    }
  }
}