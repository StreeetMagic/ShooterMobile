using Games;
using Infrastructure.Services.CoroutineRunners;
using Infrastructure.Services.StateMachines.GameLoopStateMachines.States;
using Infrastructure.Services.StaticDataServices;
using Infrastructure.Services.ZenjectFactory;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.StateMachines.GameStateMachines.States
{
  public class BootstrapState : IGameState
  {
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly IStateMachine<IGameLoopState> _gameLoopStateMachine;
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly IZenjectFactory _godFactory;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(IStateMachine<IGameState> gameStateMachine, IStateMachine<IGameLoopState> gameLoopStateMachine,
      ICoroutineRunner coroutineRunner, IStaticDataService staticDataService, IZenjectFactory godFactory
)
    {
      _gameStateMachine = gameStateMachine;
      _coroutineRunner = coroutineRunner;
      _staticDataService = staticDataService;
      _godFactory = godFactory;
      _gameLoopStateMachine = gameLoopStateMachine;
    }

    public void Enter()
    {
      RegisterGameLoopStates();

      RegisterConfigs();
      EnterNextState();
    }

    public void Exit()
    {
    }

    private void RegisterConfigs()
    {
      _staticDataService.RegisterConfigs();
    }

    private void RegisterGameLoopStates()
    {
      _gameLoopStateMachine.Register(_godFactory.Create<PlaceWallsState>());
      _gameLoopStateMachine.Register(_godFactory.Create<ChooseTowerState>());
      _gameLoopStateMachine.Register(_godFactory.Create<EnemyMoveState>());
      _gameLoopStateMachine.Register(_godFactory.Create<WinState>());
      _gameLoopStateMachine.Register(_godFactory.Create<LoseState>());
    }

    private void EnterNextState() =>
      _gameStateMachine.Enter<LoadLevelState, string>(SceneName());

    private static string SceneName() =>
      SceneManager
        .GetActiveScene()
        .name == Constants.Scenes.Initial
        ? Constants.Scenes.GameLoop
        : SceneManager.GetActiveScene().name;
  }
}