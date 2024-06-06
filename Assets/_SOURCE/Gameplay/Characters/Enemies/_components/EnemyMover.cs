using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMover
  {
    private readonly NavMeshAgent _navMeshAgent;
    private readonly Enemy _enemy;
    private readonly EnemyToTargetRotator _enemyToTargetRotator;

    private EnemyMover(NavMeshAgent navMeshAgent, Enemy enemy, EnemyToTargetRotator enemyToTargetRotator)
    {
      _navMeshAgent = navMeshAgent;
      _enemy = enemy;
      _enemyToTargetRotator = enemyToTargetRotator;
    }

    public void Move(Vector3 target, float moveSpeed)
    {
      _enemyToTargetRotator.RotateToTargetPosition((target - _enemy.transform.position).normalized);

      _navMeshAgent.SetDestination(target);
      _navMeshAgent.speed = moveSpeed;
    }
  }
}