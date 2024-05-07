using System.Collections.Generic;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;

namespace Gameplay.Bombs
{
  public class BombSpawner : MonoBehaviour
  {
    public List<Transform> SubQuest1;
    public List<Transform> SubQuest2;
    public List<Transform> SubQuest3;

    public List<List<Bomb>> Bombs;

    [Inject] private readonly GameLoopZenjectFactory _gameLoopZenjectFactory;

    private void Awake()
    {
      Bombs = new List<List<Bomb>>()
      {
        new(),
        new(),
        new()
      };
    }

    public void SpawnBombs(int subQuestIndex)
    {
      switch (subQuestIndex)
      {
        case 0:
          foreach (Transform spawnTransform in SubQuest1)
          {
            Bomb spawnBomb = SpawnBomb(spawnTransform);
            Bombs[0].Add(spawnBomb);
          }

          break;

        case 1:
          foreach (Transform spawnTransform in SubQuest2)
          {
            Bomb spawnBomb = SpawnBomb(spawnTransform);
            Bombs[1].Add(spawnBomb);
          }
          break;

        case 2:
          foreach (Transform spawnTransform in SubQuest3)
          {
            Bomb spawnBomb = SpawnBomb(spawnTransform);
            Bombs[2].Add(spawnBomb);
          }
          break;
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