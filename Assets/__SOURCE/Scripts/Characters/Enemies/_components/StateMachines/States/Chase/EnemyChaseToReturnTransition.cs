using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.Enemies.StateMachines.States.Return;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Spawners;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States.Chase
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