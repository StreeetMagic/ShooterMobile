using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyRoutePointsSwitcher : MonoBehaviour
  {
    [Inject] private EnemyRoutePointsManager _enemyRoutePointsManager;
    [Inject] private EnemyWaiter _enemyWaiter;
    [Inject] private EnemyReturnToSpawnStatus _returnToSpawnStatus;

    private void FixedUpdate()
    {
      float distance = Vector3.Distance(_enemyRoutePointsManager.NextRoutePointTransform.position, transform.position);

      //Debug.Log("Дистанция до цели " + distance);
      
      if (distance < 0.1f)
      {
        _enemyRoutePointsManager.SetRandomRoute();
        _enemyWaiter.enabled = true;
        _returnToSpawnStatus.IsReturn = false;
      }
    }
  }
}