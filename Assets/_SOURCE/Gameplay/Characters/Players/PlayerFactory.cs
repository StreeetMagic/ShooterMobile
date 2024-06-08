using AssetProviders;
using Gameplay.Characters.Players.PetSpawnPointsContainers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.TargetLocators;
using Gameplay.Weapons;
using Maps;
using PersistentProgresses;
using SaveLoadServices;
using UnityEngine;
using ZenjectFactories;

namespace Gameplay.Characters.Players
{
  public class PlayerFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _factory;
    private readonly PlayerProvider _playerProvider;
    private readonly PersistentProgressService _progressService;
    private readonly SaveLoadService _saveLoadService;
    private readonly MapProvider _mapProvider;

    public PlayerFactory(GameLoopZenjectFactory factory, IAssetProvider assetProvider,
      PlayerProvider playerProvider, PersistentProgressService progressService, SaveLoadService saveLoadService,
      MapProvider mapProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _playerProvider = playerProvider;
      _progressService = progressService;
      _saveLoadService = saveLoadService;
      _mapProvider = mapProvider;
    }

    public void Create(Transform parent)
    {
      var prefab = _assetProvider.Get<Player>();

      Player player = _factory.InstantiateMono(prefab, SpawnPosition(), parent);

      player.transform.SetParent(null);
      _playerProvider.Player = player;

      _playerProvider.Transform = player.transform;
      _playerProvider.PlayerTargetLocator = player.GetComponentInChildren<PlayerTargetLocator>();
      _playerProvider.PlayerInputHandler = _factory.InstantiateNative<PlayerInputHandler>();
      _playerProvider.PlayerRotatorController = _factory.InstantiateNative<PlayerRotatorController>();
      _playerProvider.PlayerTargetHolder = player.GetComponent<PlayerTargetHolder>();
      _playerProvider.WeaponShootingPointPoint = player.GetComponentInChildren<WeaponShootingPoint>();
      _playerProvider.PlayerStandsOnSamePosition = player.GetComponent<PlayerStandsOnSamePosition>();

      _playerProvider.PlayerHealth = player.GetComponent<PlayerHealth>();
      _playerProvider.PetSpawnPointsContainer = player.GetComponentInChildren<PetSpawnPointsContainer>();
      _playerProvider.PlayerHenSpawner = player.GetComponent<PlayerHenSpawner>();
      _playerProvider.PlayerWeaponId = player.GetComponent<PlayerWeaponId>();

      foreach (IProgressReader progressReader in player.GetComponentsInChildren<IProgressReader>())
        _saveLoadService.ProgressReaders.Add(progressReader);
    }

    public void Destroy()
    {
      Player player = _playerProvider.Player;

      if (player != null)
      {
        foreach (IProgressReader progressReader in player.GetComponentsInChildren<IProgressReader>())
          _saveLoadService.ProgressReaders.Remove(progressReader);
      }

      _playerProvider.Player = null;
  
      _playerProvider.Transform = null;
      _playerProvider.PlayerTargetLocator = null;
      _playerProvider.PlayerInputHandler = null;
      _playerProvider.PlayerRotatorController = null;
      _playerProvider.PlayerTargetHolder = null;
      _playerProvider.WeaponShootingPointPoint = null;
      _playerProvider.PlayerHealth = null;
      _playerProvider.PetSpawnPointsContainer = null;
      _playerProvider.PlayerHenSpawner = null;
      _playerProvider.PlayerWeaponId = null;
      _playerProvider.PlayerStandsOnSamePosition = null;

      Object.Destroy(player.gameObject);
    }

    private Vector3 SpawnPosition()
    {
      // return _progressService.ProjectProgress.PlayerPosition == Vector3.zero
      //   ? _mapProvider.Map.PlayerSpawnMarker.transform.position
      //   : _progressService.ProjectProgress.PlayerPosition;
      
      return _mapProvider.Map.PlayerSpawnMarker.transform.position;
    }
  }
}