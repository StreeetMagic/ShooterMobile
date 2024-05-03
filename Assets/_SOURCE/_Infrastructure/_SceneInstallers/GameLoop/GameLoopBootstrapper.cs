using Cameras;
using DataRepositories;
using DataRepositories.BackpackStorages;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Infrastructure.AudioServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.DependencyInjection;
using Infrastructure.SaveLoadServices;
using Infrastructure.Upgrades;
using Maps;
using Quests;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

public class GameLoopBootstrapper : MonoBehaviour
{
  [Inject] private GameLoopInstaller _gameLoopInstaller;
  [Inject] private PlayerFactory _playerFactory;
  [Inject] private MapFactory _mapFactory;
  [Inject] private CameraFactory _cameraFactory;
  [Inject] private EnemySpawnerFactory _enemySpawnerFactory;
  [Inject] private HeadsUpDisplayFactory _headsUpDisplayFactory;
  [Inject] private MoneyInBankStorage _moneyInBankStorage;
  [Inject] private UpgradeService _upgradeService;
  [Inject] private SaveLoadService _saveLoadService;
  [Inject] private AudioService _audioService;
  [Inject] private PlayerStatsProvider _playerStatsProvider;
  [Inject] private ICoroutineRunner _runner;
  [Inject] private QuestStorage _questStorage;
  [Inject] private BackpackStorage _backpackStorage;

  public void Start()
  {
    _saveLoadService.ProgressReaders.Add(_moneyInBankStorage);
    _saveLoadService.ProgressReaders.Add(_upgradeService);
    _saveLoadService.ProgressReaders.Add(_audioService);
    _saveLoadService.ProgressReaders.Add(_questStorage);
    _saveLoadService.LoadProgress();

    _playerStatsProvider.Start();

    _mapFactory.Create(_gameLoopInstaller.transform);
    _playerFactory.Create(_gameLoopInstaller.transform);
    _cameraFactory.Create(_gameLoopInstaller.transform);
    _enemySpawnerFactory.Create();
    _headsUpDisplayFactory.Create(_gameLoopInstaller.transform);

    _backpackStorage.Clean();
  }

  public void OnDestroy()
  {
    // _runner.StopAllCoroutines();
    _saveLoadService.ProgressReaders.Remove(_moneyInBankStorage);
    _saveLoadService.ProgressReaders.Remove(_upgradeService);
    _saveLoadService.ProgressReaders.Remove(_audioService);
    _saveLoadService.ProgressReaders.Remove(_questStorage);

     _playerFactory.Destroy();
     _mapFactory.Destroy();
  }
}