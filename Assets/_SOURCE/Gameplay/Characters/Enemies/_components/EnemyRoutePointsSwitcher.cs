using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyRoutePointsSwitcher : MonoBehaviour
  {
    [Inject] private RoutePointsManager _routePointsManager;
    [Inject] private EnemyWaiter _enemyWaiter;
    [Inject] private ReturnToSpawnStatus _returnToSpawnStatus;

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