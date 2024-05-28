using Loggers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyFromEnemyPusher : MonoBehaviour
  {
    public float Radius;
    public float Force;

    private CharacterController _enemyController;

    [Inject]
    public void Construct(DebugLogger logger, CharacterController enemyController)
    {
      _enemyController = enemyController;
    }

    private void Start()
    {
      enabled = true;
    }

    private void Update()
    {
      if (_enemyController == null || !_enemyController.enabled || !_enemyController.gameObject.activeInHierarchy)
        return;

      // ReSharper disable once Unity.PreferNonAllocApi
      var colliders = Physics.OverlapSphere(transform.position, Radius);

      foreach (var thisCollider in colliders)
      {
        if (!thisCollider.TryGetComponent(out EnemyFromEnemyPusher enemyPusher))
          continue;

        if (enemyPusher == this)
          continue;

        Vector3 positionWithoutY = new(transform.position.x, 0, transform.position.z);
        Vector3 positionWithoutY2 = new(enemyPusher.transform.position.x, 0, enemyPusher.transform.position.z);

        Vector3 direction = (positionWithoutY - positionWithoutY2).normalized;

        if (direction == Vector3.zero)
          continue;

        _enemyController.Move(direction * (Force * Time.deltaTime));
      }
    }
  }
}