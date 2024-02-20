using Infrastructure.Services.CoroutineRunners;
using Infrastructure.Services.StateMachines;
using Infrastructure.Services.StateMachines.GameLoopStateMachines.States;
using Infrastructure.Services.StateMachines.GameStateMachines.States;
using Infrastructure.Services.ZenjectFactory;

namespace Games
{
  public class Game
  {
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly IZenjectFactory _stateFactory;

    public Game
    (
      IStateMachine<IGameState> gameStateMachine,
      IStateMachine<IGameLoopState> gameLoppGameLoopStateMachine,
      IZenjectFactory stateFactory,
      ICoroutineRunner coroutineRunner
    )
    {
      _gameStateMachine = gameStateMachine;
      _stateFactory = stateFactory;
    }

    public void Start()
    {
      RegisterGameStateMachineStates();

      _gameStateMachine.Enter<BootstrapState>();
    }

    private void RegisterGameStateMachineStates()
    {
      _gameStateMachine.Register(_stateFactory.Create<BootstrapState>());
      _gameStateMachine.Register(_stateFactory.Create<LoadLevelState>());
      _gameStateMachine.Register(_stateFactory.Create<GameLoopState>());
      _gameStateMachine.Register(_stateFactory.Create<PrototypeState>());
    }
  }
}