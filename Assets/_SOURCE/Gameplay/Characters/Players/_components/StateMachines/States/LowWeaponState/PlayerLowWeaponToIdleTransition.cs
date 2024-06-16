using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.IdleState;

namespace Gameplay.Characters.Players.StateMachines.States.LowWeaponState
{
  public class PlayerLowWeaponToIdleTransition : PlayerTransition
  {
    private readonly PlayerWeaponLowerer _playerWeaponLowerer;

    public PlayerLowWeaponToIdleTransition(PlayerWeaponLowerer playerWeaponLowerer)
    {
      _playerWeaponLowerer = playerWeaponLowerer;
    }

    public override void Tick()
    {
      if (!_playerWeaponLowerer.IsLowered)
        Process<PlayerIdleState>();

      _playerWeaponLowerer.Tick();
    }
  }
}