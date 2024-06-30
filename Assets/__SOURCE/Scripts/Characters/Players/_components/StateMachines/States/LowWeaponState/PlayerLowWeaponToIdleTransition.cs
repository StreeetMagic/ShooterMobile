using Characters.FiniteStateMachines;
using Characters.Players._components.StateMachines.States.IdleState;

namespace Characters.Players._components.StateMachines.States.LowWeaponState
{
  public class PlayerLowWeaponToIdleTransition : Transition
  {
    private readonly PlayerWeaponLowerer _playerWeaponLowerer;

    public PlayerLowWeaponToIdleTransition(PlayerWeaponLowerer playerWeaponLowerer)
    {
      _playerWeaponLowerer = playerWeaponLowerer;
    }

    public override void Tick()
    {
      if (!_playerWeaponLowerer.IsLowered)
        Enter<PlayerIdleState>();

      _playerWeaponLowerer.Tick();
    }
  }
}