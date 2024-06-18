using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.RiseWeaponState;

namespace Gameplay.Characters.Players.StateMachines.States.IdleState
{
  public class PlayerIdleToRiseWeaponTransition : Transition
  {
    private readonly PlayerTargetHolder _playerTargetHolder;
    private readonly PlayerWeaponMagazineReloader _playerWeaponMagazineReloader;

    public PlayerIdleToRiseWeaponTransition(PlayerTargetHolder playerTargetHolder, PlayerWeaponMagazineReloader playerWeaponMagazineReloader)
    {
      _playerTargetHolder = playerTargetHolder;
      _playerWeaponMagazineReloader = playerWeaponMagazineReloader;
    }

    public override void Tick()
    {
      if (_playerWeaponMagazineReloader.IsActive)
        return;

      if (_playerTargetHolder.HasTarget)
        Enter<PlayerRiseWeaponState>();
    }
  }
}