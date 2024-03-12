using System.Collections.Generic;
using Configs.Resources.Enemies;
using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Gameplay.Characters.Healths;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    private IStaticDataService _staticDataService;

    [field: SerializeField] public EnemyId Id { get; private set; }

    [Inject]
    public void Construct(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public void Init(List<SpawnPoint> routePoints)
    {
      EnemyConfig enemyConfig =
        _staticDataService
          .ForEnemy(Id);

      GetComponentInChildren<EnemyMover>()
        .Init(enemyConfig, routePoints);

      GetComponentInChildren<Health>()
        .Init(enemyConfig);
    }
  }
}