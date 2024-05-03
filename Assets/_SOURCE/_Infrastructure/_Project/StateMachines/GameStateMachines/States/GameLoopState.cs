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

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class GameLoopState : IGameState
  {
    private Transform _sceneTransform;

    private readonly PlayerFactory _playerFactory;
    private readonly MapFactory _mapFactory;
    private readonly CameraFactory _cameraFactory;
    private readonly EnemySpawnerFactory _enemySpawnerFactory;
    private readonly HeadsUpDisplayFactory _headsUpDisplayFactory;
    private readonly MoneyInBankStorage _moneyInBankStorage;
    private readonly UpgradeService _upgradeService;
    private readonly SaveLoadService _saveLoadService;
    private readonly AudioService _audioService;
    private readonly PlayerStatsProvider _playerStatsProvider;
    private readonly ICoroutineRunner _runner;
    private readonly QuestStorage _questStorage;
    private readonly BackpackStorage _backpackStorage;

    public GameLoopState(PlayerFactory playerFactory, MapFactory mapFactory,
      CameraFactory cameraFactory, EnemySpawnerFactory enemySpawnerFactory,
      HeadsUpDisplayFactory headsUpDisplayFactory, MoneyInBankStorage moneyInBankStorage, UpgradeService upgradeService,
      SaveLoadService saveLoadService, AudioService audioService, PlayerStatsProvider playerStatsProvider, ICoroutineRunner runner
      , QuestStorage questStorage, BackpackStorage backpackStorage)
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
      _playerStatsProvider = playerStatsProvider;
      _runner = runner;
      _questStorage = questStorage;
      _backpackStorage = backpackStorage;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }
  }
}