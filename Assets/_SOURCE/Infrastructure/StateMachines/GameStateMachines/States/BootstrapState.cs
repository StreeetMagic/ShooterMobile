using Infrastructure.CoroutineRunners;
using Infrastructure.DataRepositories;
using Infrastructure.Games;
using Infrastructure.SceneLoaders;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class BootstrapState : IGameState
  {
    private readonly ICoroutineRunner _coroutineRunner;

    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(IStateMachine<IGameState> gameStateMachine,
      ICoroutineRunner coroutineRunner, IStaticDataService staticDataService,
      SceneLoader sceneLoader)
    {
      _gameStateMachine = gameStateMachine;
      _coroutineRunner = coroutineRunner;
      _staticDataService = staticDataService;
      _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
      LoadInitialScene();
    }

    private void LoadInitialScene()
    {
      _sceneLoader.Load(sceneName =>
      {
        _staticDataService.LoadConfigs();
        EnterNextState();
      });
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