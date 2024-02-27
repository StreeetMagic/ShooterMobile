using System;
using System.Collections.Generic;
using _SOURCE.Gameplay.Characters.Enemies;
using Infrastructure.Services.StaticDataServices;
using UnityEngine;
using Zenject;

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
    EnemyConfig enemyConfig = _staticDataService.ForEnemy(Id);

    GetComponentInChildren<EnemyMover>()
      .Init(enemyConfig, routePoints);
  }
}