using System.Collections.Generic;
using Infrastructure.ZenjectFactories;
using Maps;
using Maps.Markers.SubQuestMarkers.BombDefuse;
using UnityEngine;
using Zenject;

namespace Gameplay.Bombs
{
  public class BombSpawner : MonoBehaviour
  {
    [Inject] private readonly GameLoopZenjectFactory _gameLoopZenjectFactory;
    [Inject] private readonly MapProvider _mapProvider;

    public List<Bomb> Bombs { get; } = new();

    public void SpawnBombs()
    {
      foreach (BombDefuseMarker marker in _mapProvider.Map.BombDefuseMarkers)
      {
        Bombs.Add(SpawnBomb(marker.transform));
      }
    }

    private Bomb SpawnBomb(Transform spawnTransform)
    {
      return
        _gameLoopZenjectFactory
          .InstantiateMono<Bomb>(spawnTransform.position);
    }
  }
}