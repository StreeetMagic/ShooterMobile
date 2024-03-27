using System.Collections;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class HealthStatusController : MonoBehaviour
  {
    private Enemy _enemy;
    private EnemyHealth _enemyHealth;
    private CoroutineDecorator _coroutine;

    private ICoroutineRunner _coroutineRunner;

    [Inject]
    private void Construct(EnemyHealth enemyHealth, ICoroutineRunner coroutineRunner, Enemy enemy)
    {
      _coroutineRunner = coroutineRunner;
      _enemyHealth = enemyHealth;
      _enemy = enemy;
      
      _enemyHealth.Damaged += OnDamaged;
      _coroutine = new CoroutineDecorator(_coroutineRunner, TakeHit);
    }

    private EnemyConfig Config => _enemy.Config;
    public bool IsHit { get; private set; }
    private float RunTime => Config.RunTime;

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