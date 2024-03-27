using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Gameplay.Characters.Enemies.StateMachines.States;
using Infrastructure.StateMachines;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    public EnemyConfig Config;
    public List<SpawnPoint> SpawnPoints;
  }
}