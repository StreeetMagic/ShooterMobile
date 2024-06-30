using System.Collections.Generic;
using Characters.FiniteStateMachines;

namespace Characters.Players._components.StateMachines.States.AttackState
{
  public class PlayerAttackState : State
  {
    private readonly PlayerWeaponAttacker _playerWeaponAttacker;
    private readonly PlayerTargetHolder _targetHolder;
    private readonly PlayerRotator _rotator;

    public PlayerAttackState(List<Transition> transitions, PlayerWeaponAttacker playerWeaponAttacker,
      PlayerTargetHolder targetHolder, PlayerRotator rotator)
      : base(transitions)
    {
      _playerWeaponAttacker = playerWeaponAttacker;
      _targetHolder = targetHolder;
      _rotator = rotator;
    }

    public override void Enter()
    {
      _playerWeaponAttacker.ResetValues();
    }

    protected override void OnTick()
    {
      _playerWeaponAttacker.Tick();

      if (_targetHolder.HasTarget)
        _rotator.RotateTowardsDirection(_targetHolder.LookDirectionToTarget);
    }

    public override void Exit()
    {
    }
  }
}