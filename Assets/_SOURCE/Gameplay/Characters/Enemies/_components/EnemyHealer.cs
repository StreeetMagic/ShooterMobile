using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyHealer : MonoBehaviour
  {
    private float _heal;
    private float _timer;

    [Inject] private EnemyHealth _enemyHealth;
    [Inject] private HitStatus _hitStatus;
    [Inject] private EnemyConfig _config;

    private float HealMultiplier => _config.HealMultiplier;

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
        if (_timer >= _config.RunTime)
        {
          _enemyHealth.Current.Value++;
          _heal = 0;
        }
      }
    }
  }
}