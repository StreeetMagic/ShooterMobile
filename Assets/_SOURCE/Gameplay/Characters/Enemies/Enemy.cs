using System.Collections.Generic;
using Gameplay.Spawners;
using Gameplay.Spawners.SpawnPoints;
using UnityEngine;
using Zenject.Source.Factories;

namespace Gameplay.Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    public EnemyInstaller Installer;
    
    public class Factory : PlaceholderFactory<EnemyConfig, List<SpawnPoint>, Transform, EnemySpawner, Enemy>
    {
    }
  }
}