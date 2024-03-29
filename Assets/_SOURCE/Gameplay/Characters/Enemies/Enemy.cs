using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    [Inject]
    public void Construct(EnemyComponentsProvider componentsProvider)
    {
      ComponentsProvider = componentsProvider;
    }

    public EnemyComponentsProvider ComponentsProvider { get; set; }
  }

  public class EnemyComponentsProvider
  {
    public EnemyConfig Config { get; set; }
    public List<SpawnPoint> SpawnPoints { get; set; }
    public EnemyHealth Health { get; set; }
  }
}