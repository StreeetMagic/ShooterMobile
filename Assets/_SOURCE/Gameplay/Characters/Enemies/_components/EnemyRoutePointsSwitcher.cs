using Gameplay.Characters.Enemies.Movers;
using Loggers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyRoutePointsSwitcher : MonoBehaviour
  {
    private RoutePointsManager _routePointsManager;
    private EnemyWaiter _enemyWaiter;
    private ReturnToSpawnStatus _returnToSpawnStatus;
    private DebugLogger _logger;

    [Inject]
    public void Construct(RoutePointsManager routePointsManager, EnemyWaiter enemyWaiter,
      ReturnToSpawnStatus returnToSpawnStatus, DebugLogger logger)
    {
      _routePointsManager = routePointsManager;
      _enemyWaiter = enemyWaiter;
      _returnToSpawnStatus = returnToSpawnStatus;
      _logger = logger;
    }

    private void FixedUpdate()
    {
      float distance = Vector3.Distance(_routePointsManager.NextRoutePointTransform.position, transform.position);

      if (distance < 0.1f)
      {
        // _logger.Log("Switch route");

        _routePointsManager.SetRandomRoute();
        _enemyWaiter.enabled = true;
        _returnToSpawnStatus.IsReturn = false;
      }
    }
  }
}