using Gameplay.Characters.Enemies.StateMachines.States.Idle;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Spawners;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States.Return
{
  public class EnemyReturnToIdleTransition : Transition
  {
    private const float Distance = 0.5f;

    private readonly Transform _transform;
    private readonly EnemySpawner _spawner;

    public EnemyReturnToIdleTransition(Transform transform, EnemySpawner spawner)
    {
      _transform = transform;
      _spawner = spawner;
    }

    public override void Tick()
    {
      if (Vector3.Distance(_spawner.transform.position, _transform.position) < Distance)
        Enter<EnemyIdleState>();
    }
  }
}