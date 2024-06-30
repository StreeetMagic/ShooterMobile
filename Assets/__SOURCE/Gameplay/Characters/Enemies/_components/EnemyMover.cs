using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMover
  {
    private readonly NavMeshAgent _navMeshAgent;
    private readonly Transform _transform;

    private EnemyMover(NavMeshAgent navMeshAgent, Transform transform)
    {
      _navMeshAgent = navMeshAgent;
      _transform = transform;
    }

    public void Move(Vector3 target, float moveSpeed)
    {
      _navMeshAgent.isStopped = false;
      _navMeshAgent.SetDestination(target);
      _navMeshAgent.speed = moveSpeed;
    }

    public void Stop()
    {
      _navMeshAgent.SetDestination(_transform.position);
      _navMeshAgent.isStopped = true;
      _navMeshAgent.speed = 0f;
    }
  }
}