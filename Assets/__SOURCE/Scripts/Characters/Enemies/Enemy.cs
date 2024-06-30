using System.Collections.Generic;
using Characters.Enemies.Configs;
using Spawners;
using Spawners.SpawnPoints;
using UnityEngine;
using Zenject;
using Zenject.Source.Factories;

namespace Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    [Inject] public IHealth Health { get; }

    public class Factory : PlaceholderFactory<EnemyConfig, List<SpawnPoint>, EnemySpawner, Enemy>
    {
    }
  }
}