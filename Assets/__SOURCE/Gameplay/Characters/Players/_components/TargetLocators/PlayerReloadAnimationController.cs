using Gameplay.Characters.Players.Animators;
using Zenject;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerReloadAnimationController : ITickable
  {
    private readonly PlayerWeaponMagazineReloader _reloader;
    private readonly PlayerAnimator _playerAnimator;

    private bool _isReloading;

    public PlayerReloadAnimationController(PlayerWeaponMagazineReloader reloader, PlayerAnimator playerAnimator)
    {
      _reloader = reloader;
      _playerAnimator = playerAnimator;
    }

    public void Tick()
    {
      if (_reloader.IsActive && _isReloading == false)
      {
        _playerAnimator.OffStateShooting();
        _playerAnimator.PlayReload();
        _isReloading = true;
      }
      else if (_reloader.IsActive == false && _isReloading)
      {
        _playerAnimator.StopReload();
        _isReloading = false;
      }
    }
  }
}