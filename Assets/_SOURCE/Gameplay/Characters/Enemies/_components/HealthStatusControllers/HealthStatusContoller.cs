using System.Collections;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.StateMachines.States;
using Infrastructure.CoroutineRunners;
using Infrastructure.StateMachines;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class HealthStatusController
  {
    private readonly Enemy _enemy;
    private readonly EnemyHealth _enemyHealth;
    private readonly CoroutineDecorator _coroutine;
    private readonly StateMachine<IEnemyState> _stateMachine;

    private HealthStatusController(EnemyHealth enemyHealth, ICoroutineRunner coroutineRunner,
      Enemy enemy, StateMachine<IEnemyState> stateMachine)
    {
      _enemyHealth = enemyHealth;
      _enemy = enemy;
      _stateMachine = stateMachine;

      _enemyHealth.Damaged += OnDamaged;
      _enemyHealth.Died += OnDied;
      _coroutine = new CoroutineDecorator(coroutineRunner, TakeHit);
    }

    private void OnDied(EnemyConfig arg1, EnemyHealth arg2)
    {
      _stateMachine.Enter<EnemyDeadState>();
    }

    private EnemyConfig Config => _enemy.ComponentsProvider.Config;
    public bool IsHit { get; private set; }
    private float RunTime => Config.RunTime;

    private void OnDamaged(int damage)
    {
      EnterChaseState();

      _coroutine.Stop();
      IsHit = true;
      _coroutine.Start();
    }

    private void EnterChaseState()
    {
      if (_stateMachine.ActiveState is EnemyPatrolState || _stateMachine.ActiveState is EnemyWaitState)
      {
        _stateMachine.Enter<EnemyChaseState>();
      }
    }

    private IEnumerator TakeHit()
    {
      yield return new WaitForSeconds(RunTime);

      IsHit = false;
    }
  }
}