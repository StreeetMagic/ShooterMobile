using System.Collections;
using System.Collections.Generic;
using _SOURCE.Gameplay.Characters.Enemies;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyMover : MonoBehaviour
{
  private EnemyConfig _enemyConfig;
  private CharacterController _characterController;
  private List<RoutePoint> _routePoints;
  private int _currentRouteIndex = 0;
  private Vector3 _targetPosition;
  private bool _isMoving = false;

  private float MoveSpeed => _enemyConfig.MoveSpeed;

  public void Init(EnemyConfig enemyConfig, List<RoutePoint> routePoints)
  {
    _enemyConfig = enemyConfig;
    _characterController = GetComponent<CharacterController>();
    _routePoints = ShuffleRoutePoints(routePoints);
  }

  private List<RoutePoint> ShuffleRoutePoints(List<RoutePoint> points)
  {
    for (int i = 0; i < points.Count; i++)
    {
      int randIndex = Random.Range(i, points.Count);
      RoutePoint temp = points[randIndex];
      points[randIndex] = points[i];
      points[i] = temp;
    }

    return points;
  }

  public void Update()
  {
    if (_isMoving == false && _routePoints != null && _routePoints.Count > 0)
    {
      _targetPosition = _routePoints[Random.Range(0, _routePoints.Count)].transform.position;
      StartCoroutine(MoveToTargetPosition());
    }
  }

  private IEnumerator MoveToTargetPosition()
  {
    _isMoving = true;

    while (Vector3.Distance(transform.position, _targetPosition) > 0.1f)
    {
      Vector3 moveDirection = (_targetPosition - transform.position).normalized;
      _characterController.Move(moveDirection * (MoveSpeed * Time.deltaTime));
      yield return null;
    }

    yield return new WaitForSeconds(_enemyConfig.WaitTimeAfterMove);

    _currentRouteIndex = (_currentRouteIndex + 1) % _routePoints.Count;
    _isMoving = false;
  }
}