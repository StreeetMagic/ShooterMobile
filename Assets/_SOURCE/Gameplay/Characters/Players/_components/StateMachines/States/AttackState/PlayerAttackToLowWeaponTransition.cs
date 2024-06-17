using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.LowWeaponState;
using Gameplay.Weapons;

namespace Gameplay.Characters.Players.StateMachines.States.AttackState
{
  public class PlayerAttackToLowWeaponTransition : Transition
  {
    private readonly PlayerTargetHolder _targetHolder;
    private readonly PlayerWeaponMagazineReloader _playerWeaponMagazineReloader;
    private readonly PlayerWeaponIdProvider _playerWeaponIdProvider;

    private WeaponTypeId _prevWeaponId = WeaponTypeId.Unknown;
    private WeaponTypeId _currentWeaponId = WeaponTypeId.Unknown;

    public PlayerAttackToLowWeaponTransition(PlayerTargetHolder targetHolder, PlayerWeaponMagazineReloader playerWeaponMagazineReloader,
      PlayerWeaponIdProvider playerWeaponIdProvider)
    {
      _targetHolder = targetHolder;
      _playerWeaponMagazineReloader = playerWeaponMagazineReloader;
      _playerWeaponIdProvider = playerWeaponIdProvider;
    }

    public override void Tick()
    {
      if (_targetHolder.HasTarget == false)
        Process<PlayerLowWeaponState>();

      if (_playerWeaponMagazineReloader.IsActive)
        Process<PlayerLowWeaponState>();

      if (_currentWeaponId == WeaponTypeId.Unknown)
      {
        _currentWeaponId = _playerWeaponIdProvider.CurrentId.Value;
        _prevWeaponId = _currentWeaponId;
      }
      else
      {
        _currentWeaponId = _playerWeaponIdProvider.CurrentId.Value;

        if (_currentWeaponId != _prevWeaponId)
        {
          _prevWeaponId = WeaponTypeId.Unknown;
          _currentWeaponId = WeaponTypeId.Unknown;
          Process<PlayerLowWeaponState>();
        }
      }
    }
  }
}