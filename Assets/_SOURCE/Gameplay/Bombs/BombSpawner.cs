using System.Collections.Generic;
using Infrastructure.ZenjectFactories;
using Maps;
using UnityEngine;
using Zenject;

namespace Gameplay.Bombs
{
  public class BombSpawner : MonoBehaviour
  {
    public List<Transform> SubQuest1;
    public List<Transform> SubQuest2;
    public List<Transform> SubQuest3;

    private GameLoopZenjectFactory _gameLoopZenjectFactory;

    [Inject]
    public void Construct(GameLoopZenjectFactory gameLoopZenjectFactory)
    {
      _gameLoopZenjectFactory = gameLoopZenjectFactory;
    }

    public void SpawnBombs(int subQuestIndex)
    {
      switch (subQuestIndex)
      {
        case 0:
          foreach (Transform spawnTransform in SubQuest1)
            SpawnBomb(spawnTransform);
          break;

        case 1:
          foreach (Transform spawnTransform in SubQuest2)
            SpawnBomb(spawnTransform);
          break;

        case 2:
          foreach (Transform spawnTransform in SubQuest3)
            SpawnBomb(spawnTransform);
          break;
      }
    }

    private void SpawnBomb(Transform spawnTransform)
    {
      _gameLoopZenjectFactory
        .InstantiateMono<Bomb>(spawnTransform.position);
    }
  }
}