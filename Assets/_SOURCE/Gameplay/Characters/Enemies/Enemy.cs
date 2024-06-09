using System.Collections.Generic;
using Gameplay.Spawners;
using Gameplay.Spawners.SpawnPoints;
using UnityEngine;
using Zenject;
using Zenject.Source.Factories;

namespace Gameplay.Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    [Inject] public IHealth Health { get; }

    public class Factory : PlaceholderFactory<EnemyConfig, List<SpawnPoint>, EnemySpawner, Enemy>
    {
    }
  }
}