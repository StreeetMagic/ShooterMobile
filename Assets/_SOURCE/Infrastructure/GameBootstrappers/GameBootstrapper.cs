using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;

namespace Infrastructure.GameBootstrappers
{
  public class GameBootstrapper : MonoBehaviour
  {
    private ProjectZenjectFactory _instantiator;
    private IStateMachine<IGameState> _gameStateMachine;

    [Inject]
    public void Construct(ProjectZenjectFactory zenjectFactory, IStateMachine<IGameState> gameStateMachine)
    {
      _instantiator = zenjectFactory;
      _gameStateMachine = gameStateMachine;
    }

    private void Awake()
    {
      _gameStateMachine.Register(_instantiator.InstantiateNative<BootstrapState>());
      _gameStateMachine.Register(_instantiator.InstantiateNative<LoadLevelState>());

      _gameStateMachine.Enter<BootstrapState>();
    }
  }
}