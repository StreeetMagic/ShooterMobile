using Infrastructure.CoroutineRunners;
using Infrastructure.DataRepositories;
using Infrastructure.LoadingCurtains;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Infrastructure.StateMachines.States;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class LoadLevelState : IGameState, IPayloadedState<string>
  {
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;
    private readonly SaveLoadService _saveLoadService;
    private readonly DataRepository _dataRepository;

    public LoadLevelState(IStateMachine<IGameState> gameStateMachine,
      ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain, SaveLoadService saveLoadService, DataRepository dataRepository)
    {
      _gameStateMachine = gameStateMachine;
      _loadingCurtain = loadingCurtain;
      _saveLoadService = saveLoadService;
      _dataRepository = dataRepository;
      _sceneLoader = new SceneLoader(coroutineRunner);
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

    public void Exit()
    {
      _loadingCurtain.Hide();
    }

    private void CommonActions()
    {
      _saveLoadService.ProgressReaders.Add(_dataRepository);
      _loadingCurtain.Show();
      _saveLoadService.LoadProgress();
    }
    
    private void OnSceneLoaded(string name)
    {
      _gameStateMachine.Enter<GameLoopState>();
    }
  }
}