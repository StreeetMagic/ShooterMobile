using System;
using System.Collections.Generic;
using Infrastructure.AssetProviders;
using UnityAssetsTools.ParticleImage.Runtime;
using Random = UnityEngine.Random;

namespace Infrastructure.VisualEffects.ParticleImages
{
  public class ParticleImageService
  {
    private readonly AssetProvider _assetProvider;
    
    private Dictionary<ParticleImageId, List<ParticleImage>> _prefabs;

    public ParticleImageService(AssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    public void LoadPrefabs()
    {
      var config = _assetProvider.GetScriptable<ParticleImagesConfig>();
      
      _prefabs = new Dictionary<ParticleImageId, List<ParticleImage>>();
      
      foreach (ParticleImageSetup setup in config.Setups)
        _prefabs.Add(setup.Id, setup.Prefabs);
    }

    public ParticleImage GetPrefab(ParticleImageId id)
    {
      if (_prefabs.TryGetValue(id, out List<ParticleImage> prefabs))
        return prefabs[Random.Range(0, prefabs.Count)];
      
      throw new Exception("Prefab not found: " + id);
    }
  }
}