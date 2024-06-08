using StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponRaiser : ITickable
  {
    private readonly PlayerMoveSpeed _playerMoveSpeed;
    private readonly IStaticDataService _staticData;

    private float _timeLeft;

    public PlayerWeaponRaiser(PlayerMoveSpeed playerMoveSpeed, IStaticDataService staticData)
    {
      _playerMoveSpeed = playerMoveSpeed;
      _staticData = staticData;
    }

    public bool IsRaised => _timeLeft <= 0;
    private float WeaponRaiseTime => _staticData.GetPlayerConfig().WeaponRaiseTime;

    public void Tick()
    {
      if (_playerMoveSpeed.IsMoving)
      {
        _timeLeft = WeaponRaiseTime;
        return;
      }

      if (_timeLeft > 0)
        _timeLeft -= Time.deltaTime;
    }
  }
}