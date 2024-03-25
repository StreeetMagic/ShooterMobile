using Cameras;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Gameplay.Upgrades;
using Infrastructure.AudioServices;
using Infrastructure.DataRepositories;
using Infrastructure.SaveLoadServices;
using Maps;
using UnityEngine;
using UserInterface.HeadsUpDisplays;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class GameLoopState : IGameState
  {
    private readonly PlayerFactory _playerFactory;
    private readonly MapFactory _mapFactory;
    private readonly CameraFactory _cameraFactory;
    private readonly EnemySpawnerFactory _enemySpawnerFactory;
    private readonly HeadsUpDisplayFactory _headsUpDisplayFactory;

    private readonly MoneyInBankStorage _moneyInBankStorage;
    private readonly UpgradeService _upgradeService;
    private readonly SaveLoadService _saveLoadService;
    private readonly AudioService _audioService;

    private Transform _sceneTransform;

    public GameLoopState(PlayerFactory playerFactory, MapFactory mapFactory,
      CameraFactory cameraFactory, EnemySpawnerFactory enemySpawnerFactory,
      HeadsUpDisplayFactory headsUpDisplayFactory, MoneyInBankStorage moneyInBankStorage, UpgradeService upgradeService,
      SaveLoadService saveLoadService, AudioService audioService)
    {
      _playerFactory = playerFactory;
      _mapFactory = mapFactory;
      _cameraFactory = cameraFactory;
      _enemySpawnerFactory = enemySpawnerFactory;
      _headsUpDisplayFactory = headsUpDisplayFactory;
      _moneyInBankStorage = moneyInBankStorage;
      _upgradeService = upgradeService;
      _saveLoadService = saveLoadService;
      _audioService = audioService;
    }

    public void Enter()
    {
      _saveLoadService.ProgressReaders.Add(_moneyInBankStorage);
      _saveLoadService.ProgressReaders.Add(_upgradeService);
      _saveLoadService.ProgressReaders.Add(_audioService);
      _saveLoadService.LoadProgress();

      _sceneTransform = GameObject.FindObjectOfType<GameLoopInstaller>().transform;

      _mapFactory.Create(_sceneTransform);
      _playerFactory.Create(_sceneTransform);
      _cameraFactory.Create(_sceneTransform);
      _enemySpawnerFactory.Create();
      _headsUpDisplayFactory.Create(_sceneTransform);
    }

    public void Exit()
    {
      _saveLoadService.ProgressReaders.Remove(_moneyInBankStorage);
      _saveLoadService.ProgressReaders.Remove(_upgradeService);
      _saveLoadService.ProgressReaders.Remove(_audioService);

      // _mapFactory.Destroy();
      _playerFactory.Destroy();
      // _cameraFactory.Destroy();
      // _enemySpawnerFactory.Destroy();
      // _headsUpDisplayFactory.Destroy();
    }
  }
}