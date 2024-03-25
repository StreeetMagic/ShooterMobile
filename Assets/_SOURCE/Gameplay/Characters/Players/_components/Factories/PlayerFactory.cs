using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.InputHandlers;
using Gameplay.Characters.Players.Movers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.Shooters;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Characters.Players.TargetLocators;
using Infrastructure.AssetProviders;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.ZenjectFactories;
using Maps;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Factories
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
      PlayerProvider playerProvider, PersistentProgressService progressService, SaveLoadService saveLoadService, MapProvider mapProvider, TickableManager tickableManager)
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

      _playerProvider.PlayerShooter = _factory.InstantiateNative<PlayerShooter>();
      _playerProvider.PlayerShooter.Initialize();

      _playerProvider.PlayerTargetHolder = _factory.InstantiateNative<PlayerTargetHolder>();
      _playerProvider.PlayerTargetHolder.Start();

      _playerProvider.PlayerAnimator = player.GetComponentInChildren<PlayerAnimator>();

      _playerProvider.PlayerAnimatorEventHandler = player.GetComponentInChildren<PlayerAnimatorEventHandler>();

      foreach (IProgressReader progressReader in player.GetComponentsInChildren<IProgressReader>())
        _saveLoadService.ProgressReaders.Add(progressReader);

      _playerProvider.PlayerShooter.Subscribe();
    }
    
    public void Destroy()
    {
      Player player  = _playerProvider.Player;
      
      foreach (IProgressReader progressReader in player.GetComponentsInChildren<IProgressReader>())
        _saveLoadService.ProgressReaders.Remove(progressReader);
    }

    private Vector3 SpawnPosition()
    {
      return _progressService.Progress.PlayerPosition == Vector3.zero
        ? _mapProvider.Map.PlayerSpawnMarker.transform.position
        : _progressService.Progress.PlayerPosition;
    }

  }
}