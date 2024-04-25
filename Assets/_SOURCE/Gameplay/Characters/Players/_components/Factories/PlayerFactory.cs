using Gameplay.Characters.Players._components.InputHandlers;
using Gameplay.Characters.Players._components.Movers;
using Gameplay.Characters.Players._components.Rotators;
using Gameplay.Characters.Players._components.TargetHolders;
using Gameplay.Characters.Players._components.TargetLocators;
using Infrastructure.AssetProviders;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.ZenjectFactories;
using Maps;
using UnityEngine;

namespace Gameplay.Characters.Players._components.Factories
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
      var prefab = _assetProvider.Get<Player>(nameof(Player));

      Player player = _factory.InstantiateMono(prefab, SpawnPosition(), parent);

      player.transform.SetParent(null);
      _playerProvider.Player = player;

      _playerProvider.PlayerMover = player.GetComponent<PlayerMover>();
      _playerProvider.PlayerRotator = player.GetComponent<PlayerRotator>();
      _playerProvider.PlayerTargetLocator = player.GetComponentInChildren<PlayerTargetLocator>();

      _playerProvider.PlayerInputHandler = _factory.InstantiateNative<PlayerInputHandler>();
      _playerProvider.PlayerRotatorController = _factory.InstantiateNative<PlayerRotatorController>();

      _playerProvider.PlayerTargetHolder = player.GetComponent<PlayerTargetHolder>();

      _playerProvider.ShootingPoint = player.GetComponent<ShootingPoint>().Transform;

      foreach (IProgressReader progressReader in player.GetComponentsInChildren<IProgressReader>())
        _saveLoadService.ProgressReaders.Add(progressReader);
    }

    public void Destroy()
    {
      Player player = _playerProvider.Player;

      foreach (IProgressReader progressReader in player.GetComponentsInChildren<IProgressReader>())
        _saveLoadService.ProgressReaders.Remove(progressReader);

      Object.Destroy(player.gameObject);
    }

    private Vector3 SpawnPosition()
    {
      return _progressService.Progress.PlayerPosition == Vector3.zero
        ? _mapProvider.Map.PlayerSpawnMarker.transform.position
        : _progressService.Progress.PlayerPosition;
    }
  }
}