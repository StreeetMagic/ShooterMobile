using System.Collections.Generic;
using Characters.Enemies.Configs;
using Characters.FiniteStateMachines;
using Spawners;

namespace Characters.Enemies._components.StateMachines.States.Return
{
  public class EnemyReturnState : State
  {
    private readonly EnemyMover _mover;
    private readonly EnemySpawner _spawner;
    private readonly EnemyConfig _config;
    private readonly EnemyAnimatorProvider _animatorProvider;

    public EnemyReturnState(List<Transition> transitions, 
      EnemyMover mover, EnemySpawner spawner, 
      EnemyAnimatorProvider animatorProvider, EnemyConfig config) : base(transitions)
    {
      _mover = mover;
      _spawner = spawner;
      _animatorProvider = animatorProvider;
      _config = config;
    }

    public override void Enter()
    {
      _mover.Move(_spawner.transform.position, _config.RunSpeed);
      _animatorProvider.Instance.PlayRun();
    }

    public override void Exit()
    {
      _mover.Stop();
      _animatorProvider.Instance.StopRun();
    }
  }
}