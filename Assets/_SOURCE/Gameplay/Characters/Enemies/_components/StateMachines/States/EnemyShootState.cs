using System.Collections;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.EnemyShooters;
using Gameplay.Characters.Enemies.TargetLocators;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.Factories;
using Infrastructure.CoroutineRunners;
using Infrastructure.StateMachines;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyShootState : IEnemyState
  {
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyShooter _enemyShooter;
    private readonly EnemyComponentsProvider _enemyComponentsProvider;
    private readonly CoroutineDecorator _coroutine;
    private readonly EnemyTargetLocator _targetLocator;
    private readonly StateMachine<IEnemyState> _stateMachine;
    private bool _isShooting;

    public EnemyShootState(PlayerProvider playerProvider,
      EnemyShooter enemyShooter, EnemyComponentsProvider enemyComponentsProvider,
      ICoroutineRunner coroutineRunner, EnemyTargetLocator targetLocator, StateMachine<IEnemyState> stateMachine)
    {
      _playerProvider = playerProvider;
      _enemyShooter = enemyShooter;
      _enemyComponentsProvider = enemyComponentsProvider;
      _targetLocator = targetLocator;
      _stateMachine = stateMachine;
      _coroutine = new CoroutineDecorator(coroutineRunner, Shooting);
    }

    private EnemyConfig Config => _enemyComponentsProvider.Config;

    public void Enter()
    {
      _targetLocator.TargetLost += OnTargetLost;
      StartShootingCoroutine();
    }

    public void Exit()
    {
      StopShootingCoroutine();
    }

    private void OnTargetLost(PlayerTargetTrigger obj)
    {
      _targetLocator.TargetLost -= OnTargetLost;

      StopShootingCoroutine();

      _stateMachine.Enter<EnemyChaseState>();
    }

    private void StopShootingCoroutine()
    {
      if (_coroutine.IsRunning)
        _coroutine.Stop();
    }

    private void StartShootingCoroutine()
    {
      if (_coroutine.IsRunning == false)
      {
        _isShooting = true;
        _coroutine.Start();
      }
    }

    private IEnumerator Shooting()
    {
      while (_isShooting)
      {
        _enemyShooter.Shoot();

        //PlayerAnimator.Shoot();

        int fireRate = Config.FireRate;

        float coolDown = 1f / fireRate;

        yield return new WaitForSeconds(coolDown);
      }
    }
  }
}