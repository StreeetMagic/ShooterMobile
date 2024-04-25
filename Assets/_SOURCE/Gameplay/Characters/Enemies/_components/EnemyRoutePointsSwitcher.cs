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

    [Inject]
    public void Construct(RoutePointsManager routePointsManager, EnemyWaiter enemyWaiter,
      ReturnToSpawnStatus returnToSpawnStatus, DebugLogger logger)
    {
      _routePointsManager = routePointsManager;
      _enemyWaiter = enemyWaiter;
      _returnToSpawnStatus = returnToSpawnStatus;
    }

    private void FixedUpdate()
    {
      float distance = Vector3.Distance(_routePointsManager.NextRoutePointTransform.position, transform.position);

      if (distance < 0.1f)
      {
        _routePointsManager.SetRandomRoute();
        _enemyWaiter.enabled = true;
        _returnToSpawnStatus.IsReturn = false;
      }
    }
  }
}