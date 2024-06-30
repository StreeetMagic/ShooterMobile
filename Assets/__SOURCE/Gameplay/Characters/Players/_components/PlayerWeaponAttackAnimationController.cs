using System;
using Gameplay.Characters.Players.Animators;
using Gameplay.Weapons;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponAttackAnimationController
  {
    private readonly PlayerAnimator _playerAnimator;

    public PlayerWeaponAttackAnimationController(PlayerAnimator playerAnimator)
    {
      _playerAnimator = playerAnimator;
    }

    public void Play(WeaponTypeId id, float meleeAttackDuration)
    {
      switch (id)
      {
        case WeaponTypeId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(id), id, null);

        case WeaponTypeId.Knife:
          _playerAnimator.PlayRandomKnifeHitAnimation(meleeAttackDuration);
          break;

        case WeaponTypeId.DesertEagle:
          _playerAnimator.PlayPistolShoot();
          break;

        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          _playerAnimator.PlayRifleShoot();
          break;

        case WeaponTypeId.Xm1014:
          _playerAnimator.PlayShotgunShoot();
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(id), id, null);
      }
    }
  }
}