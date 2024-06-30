using Characters.Enemies._components.StateMachines.States.Return;
using Characters.Enemies.Configs;
using Characters.FiniteStateMachines;
using Spawners;
using UnityEngine;

namespace Characters.Enemies._components.StateMachines.States.Chase
{
  public class EnemyChaseToReturnTransition : Transition
  {
    private readonly EnemySpawner _spawner;
    private readonly EnemyConfig _config;
    private readonly Transform _transform;

    public EnemyChaseToReturnTransition(EnemySpawner spawner,
      EnemyConfig config, Transform transform)
    {
      _spawner = spawner;
      _config = config;
      _transform = transform;
    }

    public override void Tick()
    {
      if (Vector3.Distance(_spawner.transform.position, _transform.position) > _config.PatrolingRadius)
        Enter<EnemyReturnState>();
    }
  }
}