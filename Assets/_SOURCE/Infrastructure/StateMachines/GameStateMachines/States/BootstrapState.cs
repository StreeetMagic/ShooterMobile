using Configs.Resources.SoundConfigs.Scripts;
using Infrastructure.AudioServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.DataRepositories;
using Infrastructure.Games;
using Infrastructure.SceneLoaders;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class BootstrapState : IGameState
  {
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly SceneLoader _sceneLoader;
    private readonly AudioService _audioService;

    public BootstrapState(IStateMachine<IGameState> gameStateMachine,
      ICoroutineRunner coroutineRunner, IStaticDataService staticDataService,
      SceneLoader sceneLoader, AudioService audioService)
    {
      _gameStateMachine = gameStateMachine;
      _coroutineRunner = coroutineRunner;
      _staticDataService = staticDataService;
      _sceneLoader = sceneLoader;
      _audioService = audioService;
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
        _audioService.PlayMusic(MusicId.Game);
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