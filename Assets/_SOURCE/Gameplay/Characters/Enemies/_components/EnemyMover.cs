using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMover
  {
    private readonly NavMeshAgent _navMeshAgent;

    private EnemyMover(NavMeshAgent navMeshAgent, Enemy enemy)
    {
      _navMeshAgent = navMeshAgent;
    }

    public void Move(Vector3 target, float moveSpeed)
    {
      _navMeshAgent.SetDestination(target);
      _navMeshAgent.speed = moveSpeed;
    }

    public void Stop()
    {
      _navMeshAgent.SetDestination(_navMeshAgent.transform.position);
      _navMeshAgent.speed = 0f;
    }
  }
}