using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States.Chase
{
  public class EnemyChaseState : State
  {
    private readonly EnemyMover _mover;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;

    private bool _exited;

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
      _animatorProvider.Instance.PlayRun();
    }

    public override void Tick()
    {
      base.Tick();

      if (_exited)
        return;
      
      _mover.Move(_playerProvider.Instance.transform.position, _config.RunSpeed);
    }

    public override void Exit()
    {
      _exited = true;
      _mover.Stop();
      _animatorProvider.Instance.StopRun();
    }
  }
}