using Gameplay.Characters.Players.Animators;
using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponRaiser : ITickable
  {
    private readonly PlayerMoveSpeed _playerMoveSpeed;
    private readonly ConfigService _config;
    private readonly PlayerTargetHolder _playerTargetHolder;
    private readonly PlayerProvider _playerProvider;
    private readonly PlayerAnimator _playerAnimator;

    private float _timeLeft;
    private bool _isRising;

    public PlayerWeaponRaiser(PlayerMoveSpeed playerMoveSpeed, ConfigService config,
      PlayerTargetHolder playerTargetHolder, PlayerProvider playerProvider, PlayerAnimator playerAnimator)
    {
      _playerMoveSpeed = playerMoveSpeed;
      _config = config;
      _playerTargetHolder = playerTargetHolder;
      _playerProvider = playerProvider;
      _playerAnimator = playerAnimator;
    }

    public bool IsRaised => _timeLeft <= 0;

    public void Tick()
    {
      if (_playerMoveSpeed.IsMoving || _playerTargetHolder.HasTarget == false)
      {
        _timeLeft = _config.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).RaiseTime;

        if (_isRising)
        {
          _isRising = false;
        }
        
        _playerAnimator.OffStateShooting();

        return;
      }

      if (_isRising == false)
      {
        _isRising = true;
      }
      
      _playerAnimator.OnStateShooting();

      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        
        if (_timeLeft < 0)
          _timeLeft = 0;
      }
    }
  }
}