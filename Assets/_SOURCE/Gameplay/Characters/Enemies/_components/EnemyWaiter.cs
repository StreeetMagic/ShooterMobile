using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyWaiter : MonoBehaviour
  {
    private float _currentTime;

    [Inject] private EnemyConfig _config;
    [Inject] private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;

    private float WaitTimeAfterMove => _config.WaitTimeAfterMove;

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