using Gameplay.Characters.Players;
using StaticDataServices;
using UnityEngine;
using Zenject;

public class PlayerWeaponRaiser : MonoBehaviour
{
  [Inject] private PlayerMoveSpeed _playerMoveSpeed;
  [Inject] private IStaticDataService _staticData;

  private float _timeLeft;

  public bool IsRaised => _timeLeft <= 0;
  private float WeaponRaiseTime => _staticData.GetPlayerConfig().WeaponRaiseTime;

  public void Update()
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