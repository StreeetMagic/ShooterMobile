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

    [Inject]
    private void Construct(EnemyHealth enemyHealth, ICoroutineRunner coroutineRunner,
      Enemy enemy)
    {
      _enemyHealth = enemyHealth;
      _enemy = enemy;

      _enemyHealth.Damaged += OnDamaged;

      _coroutine = new CoroutineDecorator(coroutineRunner, TakeHit);
    }

    private EnemyConfig Config => _enemy.Config;
    public bool IsHit { get; set; }
    private float RunTime => 5;

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