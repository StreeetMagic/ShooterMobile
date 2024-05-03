using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using UnityEngine;
using Zenject;
using Zenject.Source.Main;

namespace Infrastructure.GameBootstrappers
{
  public class GameLoopBootsTrapper : MonoBehaviour
  {
    private IStateMachine<IGameState> _stateMachine;
    private IInstantiator _instantiator;

    [Inject]
    public void Construct(IStateMachine<IGameState> stateMachine,
      IInstantiator instantiator)
    {
      _stateMachine = stateMachine;
      _instantiator = instantiator;
    }

    private void Awake()
    {
      var gameLoopState = _instantiator.Instantiate<GameLoopState>();
      _stateMachine.Register(gameLoopState);
      _stateMachine.Enter<GameLoopState>();
    }
  }
}