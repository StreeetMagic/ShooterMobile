using Infrastructure.Games;
using Infrastructure.LoadingCurtains;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Infrastructure.StateMachines.States;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class LoadLevelState : IGameState, IPayloadedState<string>, IPayloadedState<string, string>
  {
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;
    private readonly SaveLoadService _saveLoadService;

    public LoadLevelState(IStateMachine<IGameState> gameStateMachine,
      LoadingCurtain loadingCurtain, SaveLoadService saveLoadService,
      SceneLoader sceneLoader)
    {
      _gameStateMachine = gameStateMachine;
      _loadingCurtain = loadingCurtain;
      _saveLoadService = saveLoadService;

      _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
      CommonActions();
      _sceneLoader.Load(OnSceneLoaded);
    }

    public void Enter(string sceneName)
    {
      CommonActions();
      _sceneLoader.Load(sceneName, OnSceneLoaded);
    }

    public void Enter(string emptyScene, string nextScene)
    {
      CommonActions();
      _sceneLoader.Load(emptyScene, LoadGameLoopScene);
    }

    private void LoadGameLoopScene(string nextScene)
    {
      _sceneLoader.Load(ProjectConstants.Scenes.GameLoop, OnSceneLoaded);
    }

    public void Exit()
    {
      _loadingCurtain.Hide();
    }

    private void CommonActions()
    {
      _loadingCurtain.Show();
      _saveLoadService.LoadProgress();
    }

    private void OnSceneLoaded(string name)
    {
      switch (name)
      {
        case ProjectConstants.Scenes.Initial:
          _gameStateMachine.Enter<BootstrapState>();
          break;

        case ProjectConstants.Scenes.GameLoop:
          break;

        case ProjectConstants.Scenes.Empty:
          break;
      }
    }
  }
}