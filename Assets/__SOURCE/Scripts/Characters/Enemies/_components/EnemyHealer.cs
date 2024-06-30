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

    public void Heal()
    {
      if (_enemyHealth.Current.Value >= _enemyHealth.Initial)
        return;

      float healthPerSecond = _config.HealthRegenerationRate;

      _heal += healthPerSecond * Time.deltaTime;
      _enemyHealth.Current.Value = Mathf.Min(_enemyHealth.Current.Value + _heal, _enemyHealth.Initial);
      _heal = 0;
    }
  }
}