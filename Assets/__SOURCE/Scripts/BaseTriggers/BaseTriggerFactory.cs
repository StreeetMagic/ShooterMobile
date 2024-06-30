using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;

namespace Gameplay.BaseTriggers
{
  public class BaseTriggerFactory
  {
    private readonly GameLoopZenjectFactory _factory;
    private readonly AssetProvider _assetProvider;

    public BaseTriggerFactory(GameLoopZenjectFactory factory, AssetProvider assetProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
    }

    public void Create(Transform parent)
    {
      BaseTrigger prefab = _assetProvider.Get<BaseTrigger>();
      BaseTrigger trigger = _factory.InstantiateMono(prefab, parent);

      trigger.transform.parent = null;
    }
  }
}