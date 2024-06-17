using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.LowWeaponState;

namespace Gameplay.Characters.Players.StateMachines.States.AttackState
{
  public class PlayerAttackToLowWeaponTransition : PlayerTransition
  {
    private readonly PlayerTargetHolder _targetHolder;
    private readonly PlayerWeaponMagazineReloader _playerWeaponMagazineReloader;

    public PlayerAttackToLowWeaponTransition(PlayerTargetHolder targetHolder, PlayerWeaponMagazineReloader playerWeaponMagazineReloader)
    {
      _targetHolder = targetHolder;
      _playerWeaponMagazineReloader = playerWeaponMagazineReloader;
    }

    public override void Tick()
    {
      if (_targetHolder.HasTarget == false)
        Process<PlayerLowWeaponState>();
      
      if (_playerWeaponMagazineReloader.IsActive)
        Process<PlayerLowWeaponState>();
    }
  }
}