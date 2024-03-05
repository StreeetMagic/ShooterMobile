using Infrastructure.CoroutineRunners;
using Infrastructure.Games;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class BootstrapState : IGameState
  {
    private readonly ICoroutineRunner _coroutineRunner;

    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly IZenjectFactory _godFactory;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(IStateMachine<IGameState> gameStateMachine,
      ICoroutineRunner coroutineRunner, IStaticDataService staticDataService, IZenjectFactory godFactory
    )
    {
      _gameStateMachine = gameStateMachine;
      _coroutineRunner = coroutineRunner;
      _staticDataService = staticDataService;
      _godFactory = godFactory;
    }

    public void Enter()
    {
      _staticDataService.LoadConfigs();
      EnterNextState();
    }

    public void Exit()
    {
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