using Infrastructure.SceneLoaders;
using Infrastructure.Services.CoroutineRunners;
using Infrastructure.Services.StateMachines.States;
using UnityEngine;

namespace Infrastructure.Services.StateMachines.GameStateMachines.States
{
  public class LoadLevelState : IGameState, IPayloadedState<string>
  {
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private LoadingCurtain.LoadingCurtain _loadingCurtain;

    public LoadLevelState(IStateMachine<IGameState> gameStateMachine,
      ICoroutineRunner coroutineRunner, LoadingCurtain.LoadingCurtain loadingCurtain)
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