using Infrastructure.CoroutineRunners;
using Infrastructure.LoadingCurtains;
using Infrastructure.SceneLoaders;
using Infrastructure.StateMachines.States;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class LoadLevelState : IGameState, IPayloadedState<string>
  {
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private LoadingCurtain _loadingCurtain;

    public LoadLevelState(IStateMachine<IGameState> gameStateMachine,
      ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
    {
      _gameStateMachine = gameStateMachine;
      _loadingCurtain = loadingCurtain;
      _sceneLoader = new SceneLoader(coroutineRunner);
    }

    public void Enter()
    {
      _loadingCurtain.Show();
      _sceneLoader.Load(OnSceneLoaded);
    }

    public void Enter(string sceneName)
    {
      _loadingCurtain.Show();
      _sceneLoader.Load(sceneName, OnSceneLoaded);
    }

    public void Exit()
    {
      _loadingCurtain.Hide();
    }

    private void OnSceneLoaded(string name)
    {
      _gameStateMachine.Enter<GameLoopState>();
    }
  }
}