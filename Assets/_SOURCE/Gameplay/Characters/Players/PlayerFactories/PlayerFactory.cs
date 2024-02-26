using _SOURCE.Maps;
using Games;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.ZenjectFactory;
using UnityEngine;

public class PlayerFactory
{
  private readonly IAssetProvider _assetProvider;
  private readonly IZenjectFactory _factory;
  private readonly MapFactory _mapFactory;

  public PlayerFactory(IZenjectFactory factory, IAssetProvider assetProvider, MapFactory mapFactory)
  {
    _factory = factory;
    _assetProvider = assetProvider;
    _mapFactory = mapFactory;
  }

  public Player Player { get; private set; }

  public void Create(Transform parent)
  {
    var prefab = _assetProvider.Get<Player>(nameof(Player));
    Player = _factory.Instantiate(prefab, parent);
    Player.transform.SetParent(null);
    Player.transform.position = _mapFactory.Map.PlayerSpawnPoint.transform.position;
  }
}