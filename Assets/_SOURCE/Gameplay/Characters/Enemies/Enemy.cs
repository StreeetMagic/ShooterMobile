using System;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    public EnemyInstaller Installer;
    
    public EnemyConfig Config { get; set; }
    public List<SpawnPoint> SpawnPoints { get; set; }
    public int Id { get; set; }
    public Transform SpawnerTransform { get; set; }
  }
}