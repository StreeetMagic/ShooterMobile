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

    if (_factory != null)
      Debug.Log(" Factory is not null");
  }

  public void Create()
  {
    _factory.Instantiate(_assetProvider.Get<Player>());
  }
}