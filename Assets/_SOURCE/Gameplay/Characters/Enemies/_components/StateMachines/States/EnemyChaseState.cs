using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Enemies.TargetLocators;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.Factories;
using Infrastructure.StateMachines;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyChaseState : IEnemyState, IFixedTickable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyComponentsProvider _enemyComponentsProvider;
    private readonly EnemyMover _enemyMover;
    private readonly EnemyTargetLocator _targetLocator;
    private readonly StateMachine<IEnemyState> _stateMachine;
    private readonly Enemy _enemy;
    private bool _isActive;

    public EnemyChaseState(PlayerProvider playerProvider,
      EnemyComponentsProvider enemyComponentsProvider, EnemyMover enemyMover,
      EnemyTargetLocator targetLocator, StateMachine<IEnemyState> stateMachine, Enemy enemy)
    {
      _playerProvider = playerProvider;
      _enemyComponentsProvider = enemyComponentsProvider;
      _enemyMover = enemyMover;
      _targetLocator = targetLocator;
      _stateMachine = stateMachine;
      _enemy = enemy;

      _targetLocator.TargetLocated += OnTargetLocated;
    }

    private Transform PlayerTransform => _playerProvider.Player.transform;
    private EnemyConfig Config => _enemyComponentsProvider.Config;

    public void Enter()
    {
      _isActive = true;
    }

    public void Exit()
    {
      _isActive = false;
    }

    public void FixedTick()
    {
      if (!_isActive)
        return;

      Move();

      if (_targetLocator.HasTarget)
        _stateMachine.Enter<EnemyShootState>();
    }

    private void OnTargetLocated(PlayerTargetTrigger player)
    {
      _stateMachine.Enter<EnemyShootState>();

      _targetLocator.TargetLocated -= OnTargetLocated;
    }

    private void Move()
    {
      Vector3 direction = (PlayerTransform.position - _enemy.transform.position).normalized;
      _enemyMover.Move(direction, Time.fixedDeltaTime, Config.MoveSpeed);
    }
  }
}