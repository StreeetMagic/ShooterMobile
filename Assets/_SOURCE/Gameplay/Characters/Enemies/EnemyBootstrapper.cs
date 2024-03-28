using System.Collections.Generic;
using Gameplay.Characters.Enemies.StateMachines.States;
using Infrastructure.StateMachines;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;

public class EnemyBootstrapper : IInitializable
{
  private IInstantiator _instantiator;
  private StateMachine<IEnemyState> _stateMachine;

  [Inject]
  public void Construct(IInstantiator instantiator, StateMachine<IEnemyState> stateMachine)
  {
    _instantiator = instantiator;
    _stateMachine = stateMachine;
  }

  public void Initialize()
  {
    _stateMachine.Register(_instantiator.Instantiate<EnemyBootstrapState>());
    _stateMachine.Register(_instantiator.Instantiate<EnemyWaitState>());
    _stateMachine.Register(_instantiator.Instantiate<EnemyPatrolState>());
    _stateMachine.Register(_instantiator.Instantiate<EnemyChaseState>());
    _stateMachine.Register(_instantiator.Instantiate<EnemyShootState>());
    _stateMachine.Register(_instantiator.Instantiate<EnemyReturnState>());
    _stateMachine.Register(_instantiator.Instantiate<EnemyDeadState>());
    _stateMachine.Enter<EnemyBootstrapState>();
  }
}