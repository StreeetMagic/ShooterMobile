using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    public EnemyConfig Config;
    public List<SpawnPoint> SpawnPoints;
  }
}