using Loggers;
using UnityEngine;
using Zenject;

public class EnemyFromEnemyPusher : MonoBehaviour
{
  public float Radius;
  public float Force;

  private CharacterController _enemyController;
  private DebugLogger _logger;

  [Inject]
  public void Construct(DebugLogger logger, CharacterController enemyController)
  {
    _logger = logger;
    _enemyController = enemyController;
  }

  private void Start()
  {
    enabled = true;
  }

  private void Update()
  {
    var colliders = Physics.OverlapSphere(transform.position, Radius);

    foreach (var collider in colliders)
    {
      if (collider.TryGetComponent(out EnemyFromEnemyPusher enemyPusher))
      {
        if (enemyPusher != this)
        {
          Vector3 positionWithoutY = new Vector3(transform.position.x, 0, transform.position.z);
          Vector3 positionWithoutY2 = new Vector3(enemyPusher.transform.position.x, 0, enemyPusher.transform.position.z);

          var direction = (positionWithoutY - positionWithoutY2).normalized;

          _enemyController.Move(direction * Force * Time.deltaTime);
        }
      }
    }
  }
}