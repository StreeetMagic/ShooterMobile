using System.Collections;
using System.Collections.Generic;
using Infrastructure.ZenjectFactories.SceneContext;
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
        Bomb spawnBomb = SpawnBomb(marker.transform);
        spawnBomb.Defuser.Defused += DestroyBomb;
        spawnBomb.Defuser.RespawnTime = marker.RespawnTime;
        Bombs.Add(spawnBomb);
      }
    }

    private Bomb SpawnBomb(Transform spawnTransform)
    {
      return _gameLoopZenjectFactory.InstantiateMono<Bomb>(spawnTransform.position);
    }

    private void DestroyBomb(BombDefuser defuser)
    {
      Bomb defusedBomb = defuser.Bomb;
      defusedBomb.Defuser.Defused -= DestroyBomb;
      Bombs.Remove(defusedBomb);
      Vector3 respawnPosition = defusedBomb.transform.position;
      StartCoroutine(RespawnBomb(respawnPosition, defusedBomb.Defuser.RespawnTime));
      Destroy(defusedBomb.gameObject);
    }

    private IEnumerator RespawnBomb(Vector3 position, float delay)
    {
      yield return new WaitForSeconds(delay);
      Bomb respawnedBomb = SpawnBombAtPosition(position);
      respawnedBomb.Defuser.Defused += DestroyBomb;
      Bombs.Add(respawnedBomb);
    }

    private Bomb SpawnBombAtPosition(Vector3 position)
    {
      return _gameLoopZenjectFactory.InstantiateMono<Bomb>(position);
    }
  }
}