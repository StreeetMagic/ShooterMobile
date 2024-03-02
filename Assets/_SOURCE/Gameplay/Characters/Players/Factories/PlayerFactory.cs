using Gameplay.Characters.Players.InputHandlers;
using Gameplay.Characters.Players.Movers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.Shooters;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Characters.Players.TargetLocators;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.ZenjectFactory;
using Maps;
using UnityEngine;

namespace Gameplay.Characters.Players.Factories
{
  public class PlayerFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IZenjectFactory _factory;
    private readonly MapFactory _mapFactory;
    private readonly PlayerProvider _playerProvider;

    public PlayerFactory(IZenjectFactory factory, IAssetProvider assetProvider,
      MapFactory mapFactory, PlayerProvider playerProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _mapFactory = mapFactory;
      _playerProvider = playerProvider;
    }

    public void Create(Transform parent)
    {
      var prefab = _assetProvider.Get<Player>(nameof(Player));
      Player player = _factory.Instantiate(prefab, _mapFactory.Map.PlayerSpawnPoint.transform.position, parent);
      player.transform.SetParent(null);
      _playerProvider.Player = player;

      _playerProvider.PlayerMover = player.GetComponent<PlayerMover>();
      _playerProvider.PlayerRotator = player.GetComponent<PlayerRotator>();
      _playerProvider.PlayerTargetLocator = player.GetComponentInChildren<PlayerTargetLocator>();

      _playerProvider.PlayerInputHandler = _factory.Create<PlayerInputHandler>();
      _playerProvider.PlayerRotatorController = _factory.Create<PlayerRotatorController>();
      _playerProvider.PlayerShooter = _factory.Create<PlayerShooter>();

      _playerProvider.PlayerTargetHolder = _factory.Create<PlayerTargetHolder>();
      _playerProvider.PlayerTargetHolder.Start();
    }
  }
}