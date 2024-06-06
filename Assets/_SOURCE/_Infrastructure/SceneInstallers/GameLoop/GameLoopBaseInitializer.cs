using AudioServices;
using Cameras;
using CoroutineRunners;
using CurrencyRepositories;
using CurrencyRepositories.BackpackStorages;
using DG.Tweening;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Pets.Hens;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Quests;
using Gameplay.Upgrades;
using Maps;
using Projects;
using SaveLoadServices;
using SceneLoaders;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

namespace SceneInstallers.GameLoop
{
  public abstract class GameLoopBaseInitializer : MonoBehaviour, IGameLoopInitializer
  {
    [Inject] protected SceneLoader SceneLoader;

    [Inject] private SaveLoadService _saveLoadService;
    [Inject] private GameLoopInstaller _gameLoopInstaller;
    [Inject] private PlayerFactory _playerFactory;
    [Inject] private MapFactory _mapFactory;
    [Inject] private CameraFactory _cameraFactory;
    [Inject] private EnemySpawnerFactory _enemySpawnerFactory;
    [Inject] private HeadsUpDisplayFactory _headsUpDisplayFactory;
    [Inject] private MoneyInBankStorage _moneyInBankStorage;
    [Inject] private UpgradeService _upgradeService;
    [Inject] private AudioService _audioService;
    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private ICoroutineRunner _runner;
    [Inject] private QuestStorage _questStorage;
    [Inject] private BackpackStorage _backpackStorage;

    [Inject] private HenSpawner _henSpawner;

    private void Start()
    {
      _saveLoadService.LoadProgress();

      Time.timeScale = 1f;

      _playerStatsProvider.Start();

      _mapFactory.Create(_gameLoopInstaller.transform);
      _playerFactory.Create(_gameLoopInstaller.transform);
      _cameraFactory.Create(_gameLoopInstaller.transform);
      _enemySpawnerFactory.Create();
      _headsUpDisplayFactory.Create(_gameLoopInstaller.transform);

      _backpackStorage.Clean();
    }

    public void Restart()
    {
      Destroy();
      SceneLoader.Load(ProjectConstants.Scenes.Empty, EnterScene);
    }

    protected abstract void EnterScene();

    private void Destroy()
    {
      _runner.StopAllCoroutines();
      DOTween.KillAll();
      Time.timeScale = 0f;

      _playerStatsProvider.Stop();

      _henSpawner.DeSpawnAll();
      _headsUpDisplayFactory.Destroy();
      _enemySpawnerFactory.Destroy();
      _playerFactory.Destroy();
      _mapFactory.Destroy();
    }
  }
}