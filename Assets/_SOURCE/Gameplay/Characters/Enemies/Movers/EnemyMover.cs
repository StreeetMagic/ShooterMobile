using System.Collections;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Gameplay.Characters.Healths;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Movers
{
  [RequireComponent(typeof(CharacterController))]
  public class EnemyMover : MonoBehaviour
  {
    private EnemyConfig _enemyConfig;
    private CharacterController _characterController;
    private List<SpawnPoint> _routePoints;

    private int _currentRouteIndex;
    private Vector3 _targetPosition;
    private bool _isMoving;
    private Health _health;

    private float MoveSpeed => _enemyConfig.MoveSpeed;
    private float RunSpeed => _enemyConfig.RunSpeed;

    public void Init(EnemyConfig enemyConfig, List<SpawnPoint> routePoints, Health health)
    {
      _enemyConfig = enemyConfig;
      _characterController = GetComponent<CharacterController>();
      _routePoints = ShuffleRoutePoints(routePoints);
      _health = health;
    }

    private List<SpawnPoint> ShuffleRoutePoints(List<SpawnPoint> points)
    {
      for (int i = 0; i < points.Count; i++)
      {
        int randIndex = Random.Range(i, points.Count);
        (points[randIndex], points[i]) = (points[i], points[randIndex]);
      }

      return points;
    }

    public void Update()
    {
      if (_isMoving || _routePoints == null || _routePoints.Count <= 0 || _health.IsDead)
        return;

      _targetPosition = _routePoints[Random.Range(0, _routePoints.Count)].transform.position;
      StartCoroutine(MoveToTargetPosition());
    }

    private IEnumerator MoveToTargetPosition()
    {
      _isMoving = true;

      while (Vector3.Distance(transform.position, _targetPosition) > 0.1f && _health.IsDead == false)
      {
        Vector3 moveDirection = (_targetPosition - transform.position).normalized;
        _characterController.Move(moveDirection * (MoveSpeed * Time.deltaTime));

        RotateToTargetPosition(moveDirection);

        yield return null;
      }

      yield return new WaitForSeconds(_enemyConfig.WaitTimeAfterMove);

      _currentRouteIndex = (_currentRouteIndex + 1) % _routePoints.Count;
      _isMoving = false;
    }

    private void RotateToTargetPosition(Vector3 moveDirection)
    {
      transform.rotation = Quaternion.LookRotation(moveDirection);
    }
  }
}