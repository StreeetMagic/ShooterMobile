using System.Collections;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class HealthStatusController : MonoBehaviour
  {
    private Health _health;
    private CoroutineDecorator _coroutine;
    private EnemyConfig _enemyConfig;
    private ICoroutineRunner _coroutineRunner;

    public void Init(Health health, EnemyConfig enemyConfig, ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
      _health = health;
      _enemyConfig = enemyConfig;

      _health.Damaged += OnDamaged;

      _coroutine = new CoroutineDecorator(_coroutineRunner, TakeHit);
    }

    public bool IsHit { get; private set; }
    private float RunTime => _enemyConfig.RunTime;

    private void OnDamaged(int damage)
    {
      _coroutine.Stop();
      IsHit = true;
      _coroutine.Start();
    }

    private IEnumerator TakeHit()
    {
      yield return new WaitForSeconds(RunTime);

      IsHit = false;
    }
  }
}