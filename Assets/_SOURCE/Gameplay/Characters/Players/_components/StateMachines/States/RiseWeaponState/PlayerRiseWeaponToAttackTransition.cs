using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.AttackState;

namespace Gameplay.Characters.Players.StateMachines.States.RiseWeaponState
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
        Process<PlayerAttackState>();
      
      _playerWeaponRaiser.Tick();
    }
  }
}