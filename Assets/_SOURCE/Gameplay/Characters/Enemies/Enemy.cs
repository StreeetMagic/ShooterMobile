using System.Collections.Generic;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Enemies.Spawners.RoutePoints;
using Infrastructure.Services.StaticDataServices;
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

    public void Init(List<RoutePoint> routePoints)
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