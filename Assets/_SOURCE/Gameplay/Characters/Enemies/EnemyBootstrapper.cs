using System.Collections;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.StateMachines.States;
using Infrastructure.StateMachines;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;

public class EnemyBootstrapper : MonoBehaviour
{
  private GameLoopZenjectFactory _gameLoopZenjectFactory;
  private StateMachine<IEnemyState> _stateMachine;

  [Inject]
  public void Construct(GameLoopZenjectFactory gameLoopZenjectFactory, StateMachine<IEnemyState> stateMachine)
  {
    _gameLoopZenjectFactory = gameLoopZenjectFactory;

    _stateMachine = stateMachine;
  }

  private void Awake()
  {
    _stateMachine.Register(_gameLoopZenjectFactory.InstantiateNative<EnemyBootstrapState>());
    _stateMachine.Register(_gameLoopZenjectFactory.InstantiateNative<EnemyWaitState>());
    _stateMachine.Register(_gameLoopZenjectFactory.InstantiateNative<EnemyPatrolState>());
    _stateMachine.Register(_gameLoopZenjectFactory.InstantiateNative<EnemyChaseState>());
    _stateMachine.Register(_gameLoopZenjectFactory.InstantiateNative<EnemyShootState>());
    _stateMachine.Register(_gameLoopZenjectFactory.InstantiateNative<EnemyReturnState>());
    _stateMachine.Register(_gameLoopZenjectFactory.InstantiateNative<EnemyDeadState>());

    _stateMachine.Enter<EnemyBootstrapState>();
  }
}