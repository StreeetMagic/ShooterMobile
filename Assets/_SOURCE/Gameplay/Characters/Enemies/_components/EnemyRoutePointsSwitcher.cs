using Gameplay.Characters.Enemies.Movers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyRoutePointsSwitcher : MonoBehaviour
  {
    private RoutePointsManager _routePointsManager;
    private EnemyWaiter _enemyWaiter;
    private EnemyReturnToSpawn _returnToSpawn;

    [Inject]
    public void Construct(RoutePointsManager routePointsManager, EnemyWaiter enemyWaiter, EnemyReturnToSpawn enemyReturnToSpawn)
    {
      _routePointsManager = routePointsManager;
      _enemyWaiter = enemyWaiter;
      _returnToSpawn = enemyReturnToSpawn;
    }

    private void FixedUpdate()
    {
      float distance = Vector3.Distance(_routePointsManager.NextRoutePointTransform.position, transform.position);

      if (distance < 0.1f)
      {
        _routePointsManager.SetRandomRoute();
        _enemyWaiter.enabled = true;
        _returnToSpawn.IsReturn = false;
      }
    }
  }
}