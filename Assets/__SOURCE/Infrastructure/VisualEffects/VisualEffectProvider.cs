using System;
using System.Collections.Generic;
using Infrastructure.AssetProviders;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Infrastructure.VisualEffects
{
  public class VisualEffectProvider
  {
    private readonly AssetProvider _assetProvider;

    private Dictionary<VisualEffectId, List<ParticleSystem>> _prefabs;

    public VisualEffectProvider(AssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    public void LoadPrefabs()
    {
      var config = _assetProvider.GetScriptable<VisualEffectsConfig>();

      _prefabs = new Dictionary<VisualEffectId, List<ParticleSystem>>();
      
      foreach (VisualEffectSetup setup in config.Setups)
        _prefabs.Add(setup.Id, setup.Prefabs);
    }
    
    public ParticleSystem GetPrefab(VisualEffectId id)
    {
      if (_prefabs.TryGetValue(id, out List<ParticleSystem> prefabs))
        return prefabs[Random.Range(0, prefabs.Count)];
      
       throw new Exception("Prefab not found: " + id);
    }
  }
}