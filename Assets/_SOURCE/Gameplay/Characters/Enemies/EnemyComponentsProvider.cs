using System;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyComponentsProvider
  {
    public EnemyConfig Config { get; set; }
    public List<SpawnPoint> SpawnPoints { get; set; }
    public EnemyHealth Health { get; set; }
    public Transform Transform { get; set; }

    public Action Destroyed;
  }
}