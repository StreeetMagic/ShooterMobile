using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;
using Zenject.Source.Factories;

namespace Gameplay.Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    public class Factory : PlaceholderFactory<EnemyConfig, List<SpawnPoint>, Transform, Enemy>
    {
    }
  }
}