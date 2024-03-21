using Gameplay.Upgrades;
using Infrastructure.CoroutineRunners;
using Infrastructure.DataRepositories;
using Infrastructure.LoadingCurtains;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Infrastructure.StateMachines.States;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class LoadLevelState : IGameState, IPayloadedState<string>
  {
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;
    private readonly SaveLoadService _saveLoadService;
    private readonly MoneyInBankStorage _moneyInBankStorage;
    private readonly UpgradeService _upgradeService;
    private readonly IZenjectFactory _factory;

    public LoadLevelState(IStateMachine<IGameState> gameStateMachine,
      ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain, SaveLoadService saveLoadService,
      MoneyInBankStorage moneyInBankStorage, UpgradeService upgradeService, IZenjectFactory factory)
    {
      _gameStateMachine = gameStateMachine;
      _loadingCurtain = loadingCurtain;
      _saveLoadService = saveLoadService;
      _moneyInBankStorage = moneyInBankStorage;
      _upgradeService = upgradeService;
      _factory = factory;
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
      AddProgressReaders();
      _loadingCurtain.Show();
      _saveLoadService.LoadProgress();
    }

    private void AddProgressReaders()
    {
      _saveLoadService.ProgressReaders.Add(_moneyInBankStorage);
      _saveLoadService.ProgressReaders.Add(_upgradeService);
    }

    private void OnSceneLoaded(string name)
    {
      Debug.Log("Мы сейчас находимся на сцене " + name);
      
       _gameStateMachine.Register(_factory.Create<GameLoopState>());
      // _gameStateMachine.Enter<GameLoopState>();
    }
  }
}