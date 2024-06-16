using System;
using System.Collections.Generic;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.AttackState
{
  public class PlayerAttackState : PlayerState
  {
    private readonly PlayerWeaponAttacker _playerWeaponAttacker;
    private readonly PlayerTargetHolder _targetHolder;
    private readonly PlayerRotator _rotator;

    public PlayerAttackState(List<PlayerTransition> transitions, PlayerWeaponAttacker playerWeaponAttacker,
      PlayerTargetHolder targetHolder, PlayerRotator rotator)
      : base(transitions)
    {
      _playerWeaponAttacker = playerWeaponAttacker;
      _targetHolder = targetHolder;
      _rotator = rotator;
    }

    public override void Enter()
    {
    }

    public override void Tick()
    {
      base.Tick();
      _playerWeaponAttacker.Tick();

      if (_targetHolder.HasTarget)
        _rotator.RotateTowardsDirection(_targetHolder.LookDirectionToTarget);
    }

    public override void Exit()
    {
    }
  }
}