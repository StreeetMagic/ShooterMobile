using Configs.Resources.MusicConfigs.Scripts;
using Infrastructure.AudioServices;
using Infrastructure.Games;
using Infrastructure.SceneLoaders;
using Infrastructure.StaticDataServices;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class BootstrapState : IGameState
  {
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly SceneLoader _sceneLoader;
    private readonly AudioService _audioService;

    public BootstrapState(IStateMachine<IGameState> gameStateMachine, IStaticDataService staticDataService,
      SceneLoader sceneLoader, AudioService audioService)
    {
      _gameStateMachine = gameStateMachine;
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
      _sceneLoader.Load(_ =>
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
        .name == ProjectConstants.Scenes.Initial
        ? ProjectConstants.Scenes.GameLoop
        : SceneManager.GetActiveScene().name;
  }
}