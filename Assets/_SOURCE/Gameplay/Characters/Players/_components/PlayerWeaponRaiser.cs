using Loggers;
using StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponRaiser : ITickable
  {
    private readonly PlayerMoveSpeed _playerMoveSpeed;
    private readonly IStaticDataService _staticData;
    private readonly PlayerTargetHolder _playerTargetHolder;

    private float _timeLeft;
    private bool _isRising;

    public PlayerWeaponRaiser(PlayerMoveSpeed playerMoveSpeed, IStaticDataService staticData,
      PlayerTargetHolder playerTargetHolder)
    {
      _playerMoveSpeed = playerMoveSpeed;
      _staticData = staticData;
      _playerTargetHolder = playerTargetHolder;
    }

    public bool IsRaised => _timeLeft <= 0;
    private float WeaponRaiseTime => _staticData.GetPlayerConfig().WeaponRaiseTime;

    public void Tick()
    {
      if (_playerMoveSpeed.IsMoving || _playerTargetHolder.HasTarget == false)
      {
        _timeLeft = WeaponRaiseTime;

        if (_isRising)
        {
          _isRising = false;
          new DebugLogger().Log("Надо выключить анимацию поднятия оружия игроком");
        }

        return;
      }

      if (_isRising == false)
      {
        new DebugLogger().Log("Надо включить анимацию поднятия оружия игроком");
        _isRising = true;
      }

      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
      }
    }
  }
}