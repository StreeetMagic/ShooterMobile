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

  public void Create(Transform parent)
  {
    var prefab = _assetProvider.Get<Player>();
    Player player = _factory.Instantiate(prefab, parent);
    player.transform.SetParent(null);
  }
}