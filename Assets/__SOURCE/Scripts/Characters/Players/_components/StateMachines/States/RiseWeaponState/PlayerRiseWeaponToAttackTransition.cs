using Characters.FiniteStateMachines;
using Characters.Players._components.StateMachines.States.AttackState;

namespace Characters.Players._components.StateMachines.States.RiseWeaponState
{
  public class PlayerRiseWeaponToAttackTransition : Transition
  {
    private readonly PlayerWeaponRaiser _playerWeaponRaiser;

    public PlayerRiseWeaponToAttackTransition(PlayerWeaponRaiser playerWeaponRaiser)
    {
      _playerWeaponRaiser = playerWeaponRaiser;
    }

    public override void Tick()
    {
      if (_playerWeaponRaiser.IsRaised)
        Enter<PlayerAttackState>();
      
      _playerWeaponRaiser.Tick();
    }
  }
}