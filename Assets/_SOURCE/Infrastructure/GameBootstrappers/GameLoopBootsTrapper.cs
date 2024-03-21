using System;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;

public class GameLoopBootsTrapper : MonoBehaviour
{
  private IStateMachine<IGameState> _stateMachine;
  private ZenjectFactory _factory;
  private IInstantiator _instantiator;

  [Inject]
  public void Construct(IStateMachine<IGameState> stateMachine, ZenjectFactory factory, IInstantiator instantiator)
  {
    _stateMachine = stateMachine;
    _factory = factory;
    _instantiator = instantiator;
  }

  private void Start()
  {
    _stateMachine.Register(_instantiator.Instantiate<GameLoopState>());
    _stateMachine.Enter<GameLoopState>();
  }
}