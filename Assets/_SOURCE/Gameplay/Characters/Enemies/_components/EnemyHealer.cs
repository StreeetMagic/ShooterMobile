using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyHealer : ITickable
  {
    private readonly IHealth _enemyHealth;
    private readonly HitStatus _hitStatus;
    private readonly EnemyConfig _config;

    private float _heal;
    private float _timer;

    public EnemyHealer(IHealth enemyHealth, HitStatus hitStatus, EnemyConfig config)
    {
      _enemyHealth = enemyHealth;
      _hitStatus = hitStatus;
      _config = config;
    }

    private float HealMultiplier => _config.HealMultiplier;

    public void Tick()
    {
      if (_enemyHealth.IsDead)
        return;

      _timer += Time.deltaTime;

      if (_hitStatus.IsHit)
      {
        _timer = 0;
        return;
      }

      if (_enemyHealth.IsFull)
        return;

      float healAmount = _config.InitialHealth;

      _heal += healAmount * Time.deltaTime * HealMultiplier;

      if (_heal >= 1)
      {
        if (_timer >= _config.HealingDelay)
        {
          _enemyHealth.Current.Value++;
          _heal = 0;
        }
      }
    }
  }
}