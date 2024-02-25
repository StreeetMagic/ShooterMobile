using Games;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.ZenjectFactory;
using UnityEngine;

public class PlayerFactory
{
  private readonly IAssetProvider _assetProvider;
  private readonly IZenjectFactory _factory;

  public PlayerFactory(IZenjectFactory factory, IAssetProvider assetProvider)
  {
    _factory = factory;
    _assetProvider = assetProvider;
  }

  public Player Player { get; private set; }

  public void Create(Transform parent)
  {
    var prefab = _assetProvider.Get<Player>(Constants.AssetsPath.Prefabs.PlayerVlad);
    Player = _factory.Instantiate(prefab, parent);
    Player.transform.SetParent(null);
  }
}