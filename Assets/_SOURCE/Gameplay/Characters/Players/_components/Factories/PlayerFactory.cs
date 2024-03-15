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

namespace Gameplay.Characters.Players.Factories
{
  public class PlayerFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IZenjectFactory _factory;
    private readonly PlayerProvider _playerProvider;
    private readonly PersistentProgressService _progressService;
    private readonly SaveLoadService _saveLoadService;
    private readonly MapProvider _mapProvider;

    public PlayerFactory(IZenjectFactory factory, IAssetProvider assetProvider,
      PlayerProvider playerProvider, PersistentProgressService progressService, SaveLoadService saveLoadService, MapProvider mapProvider)
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

      Player player = _factory.Instantiate(prefab, SpawnPosition(), parent);

      player.transform.SetParent(null);
      _playerProvider.Player = player;

      _playerProvider.PlayerMover = player.GetComponent<PlayerMover>();
      _playerProvider.PlayerRotator = player.GetComponent<PlayerRotator>();
      _playerProvider.PlayerTargetLocator = player.GetComponentInChildren<PlayerTargetLocator>();

      _playerProvider.PlayerInputHandler = _factory.Create<PlayerInputHandler>();
      _playerProvider.PlayerRotatorController = _factory.Create<PlayerRotatorController>();

      _playerProvider.PlayerShooter = _factory.Create<PlayerShooter>();
      _playerProvider.PlayerShooter.Initialize();

      _playerProvider.PlayerTargetHolder = _factory.Create<PlayerTargetHolder>();
      _playerProvider.PlayerTargetHolder.Start();

      _playerProvider.PlayerAnimator = player.GetComponentInChildren<PlayerAnimator>();

      _playerProvider.PlayerAnimatorEventHandler = player.GetComponentInChildren<PlayerAnimatorEventHandler>();

      foreach (IProgressReader progressReader in player.GetComponentsInChildren<IProgressReader>())
        _saveLoadService.ProgressReaders.Add(progressReader);

      _playerProvider.PlayerShooter.Subscribe();
    }

    private Vector3 SpawnPosition()
    {
      return _progressService.Progress.PlayerPosition == Vector3.zero
        ? _mapProvider.Map.PlayerSpawnMarker.transform.position
        : _progressService.Progress.PlayerPosition;
    }
  }
}