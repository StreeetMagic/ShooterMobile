using System;
using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.HideWeaponState;

namespace Gameplay.Characters.Players.StateMachines.States.AttackState
{
  public class PlayerAttackToHideWeaponTransition : PlayerTransition
  {
    private readonly PlayerTargetHolder _targetHolder;

    public PlayerAttackToHideWeaponTransition(PlayerTargetHolder targetHolder)
    {
      _targetHolder = targetHolder;
    }

    public override void Tick()
    {
      if (_targetHolder.HasTarget == false)
        Process<PlayerHideWeaponState>();
    }
  }
}