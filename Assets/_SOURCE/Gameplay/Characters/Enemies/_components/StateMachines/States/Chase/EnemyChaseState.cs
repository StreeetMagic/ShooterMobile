using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players;

namespace Gameplay.Characters.Enemies.StateMachines.States.Chase
{
  public class EnemyChaseState : State
  {
    private readonly EnemyMover _mover;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;

    public EnemyChaseState(List<Transition> transitions, 
      EnemyMover mover, EnemyAnimatorProvider animatorProvider, 
      PlayerProvider playerProvider, EnemyConfig config) : base(transitions)
    {
      _mover = mover;
      _animatorProvider = animatorProvider;
      _playerProvider = playerProvider;
      _config = config;
    }

    public override void Enter()
    {
      _mover.Move(_playerProvider.Instance.transform.position, _config.RunSpeed);
      _animatorProvider.Instance.PlayRun();
    }

    public override void Exit()
    {
      _animatorProvider.Instance.StopRun();
    }
  }
}