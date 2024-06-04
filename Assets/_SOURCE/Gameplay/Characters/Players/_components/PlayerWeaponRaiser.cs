using Gameplay.Characters.Players;
using UnityEngine;
using Zenject;

public class PlayerWeaponRaiser : MonoBehaviour
{
  public float RaiseTime = .2f;

  [Inject] private PlayerMoveSpeed _playerMoveSpeed;

  private float _timeLeft;

  public bool IsRaised => _timeLeft <= 0;

  public void Update()
  {
    if (_playerMoveSpeed.IsMoving)
    {
      _timeLeft = RaiseTime;
      return;
    }

    if (_timeLeft > 0)
    {
      _timeLeft -= Time.deltaTime;
      return;
    }
  }
}