using System.Collections;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class HealthStatusController : MonoBehaviour
  {
    private Health _health;
    private CoroutineDecorator _coroutine;
    private EnemyConfig _enemyConfig;

    public void Init(Health health, EnemyConfig enemyConfig)
    {
      _health = health;
      _enemyConfig = enemyConfig;

      _health.Damaged += OnDamaged;

      _coroutine = new CoroutineDecorator(this, TakeHit);
    }

    public bool IsHit { get; private set; }
    private float HasteTime => _enemyConfig.HasteTime;

    private void OnDamaged(int damage)
    {
      _coroutine.Stop();
      IsHit = true;
      _coroutine.Start();
    }

    private IEnumerator TakeHit()
    {
      yield return new WaitForSeconds(1f);

      IsHit = false;
    }
  }
}