using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyWaiter : MonoBehaviour
  {
    private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;
    private Enemy _enemy;
    private float _currentTime;

    private float WaitTimeAfterMove => _enemy.Config.WaitTimeAfterMove;

    [Inject]
    public void Construct(EnemyMoverToSpawnPoint enemyMoverToSpawnPoint, Enemy enemy)
    {
      _enemyMoverToSpawnPoint = enemyMoverToSpawnPoint;
      _enemy = enemy;
    }

    private void OnEnable()
    {
      _currentTime = 0;
      _enemyMoverToSpawnPoint.enabled = false;
    }

    private void Update()
    {
      _currentTime += Time.deltaTime;

      if (_currentTime >= WaitTimeAfterMove)
      {
        _enemyMoverToSpawnPoint.enabled = true;
        enabled = false;
      }
    }
  }
}