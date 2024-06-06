using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMover
  {
    private readonly NavMeshAgent _navMeshAgent;
    private readonly Enemy _enemy;

    private EnemyMover(NavMeshAgent navMeshAgent, Enemy enemy)
    {
      _navMeshAgent = navMeshAgent;
      _enemy = enemy;
    }

    public void Move(Vector3 target, float moveSpeed)
    {
      _navMeshAgent.SetDestination(target);
      _navMeshAgent.speed = moveSpeed;
    }
  }
}