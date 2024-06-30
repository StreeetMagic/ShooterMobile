using Characters.FiniteStateMachines;
using Characters.Players._components.StateMachines.States.IdleState;

namespace Characters.Players._components.StateMachines.States.RiseWeaponState
{
  public class PlayerRiseWeaponToIdleTransition : Transition
  {
    private readonly PlayerTargetHolder _playerTargetHolder;

    public PlayerRiseWeaponToIdleTransition(PlayerTargetHolder playerTargetHolder)
    {
      _playerTargetHolder = playerTargetHolder;
    }

    public override void Tick()
    {
      if (_playerTargetHolder.HasTarget == false)
        Enter<PlayerIdleState>();
    }
  }
}