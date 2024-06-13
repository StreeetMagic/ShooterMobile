using Infrastructure.ConfigServices;
using Loggers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponRaiser : ITickable
  {
    private readonly PlayerMoveSpeed _playerMoveSpeed;
    private readonly ConfigService _config;
    private readonly PlayerTargetHolder _playerTargetHolder;

    private float _timeLeft;
    private bool _isRising;

    public PlayerWeaponRaiser(PlayerMoveSpeed playerMoveSpeed, ConfigService config,
      PlayerTargetHolder playerTargetHolder)
    {
      _playerMoveSpeed = playerMoveSpeed;
      _config = config;
      _playerTargetHolder = playerTargetHolder;
    }

    public bool IsRaised => _timeLeft <= 0;
    private float WeaponRaiseTime => _config.PlayerConfig.WeaponRaiseTime;

    public void Tick()
    {
      if (_playerMoveSpeed.IsMoving || _playerTargetHolder.HasTarget == false)
      {
        _timeLeft = WeaponRaiseTime;

        if (_isRising)
        {
          _isRising = false;
        }

        return;
      }

      if (_isRising == false)
      {
        _isRising = true;
      }

      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
      }
    }
  }
}