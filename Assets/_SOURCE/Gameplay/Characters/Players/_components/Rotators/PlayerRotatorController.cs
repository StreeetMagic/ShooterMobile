using Gameplay.CurrencyRepositories.BackpackStorages;
using UnityEngine;

namespace Gameplay.Characters.Players.Rotators
{
  public class PlayerRotatorController
  {
    private readonly BackpackStorage _backpackStorage;
    private readonly PlayerTargetHolder _playerTargetHolder;
    private readonly PlayerRotator _playerRotator;

    public PlayerRotatorController(BackpackStorage backpackStorage, 
      PlayerTargetHolder playerTargetHolder, PlayerRotator playerRotator)
    {
      _backpackStorage = backpackStorage;
      _playerTargetHolder = playerTargetHolder;
      _playerRotator = playerRotator;
    }

    public void RotateTowardsDirection(Vector3 direction)
    {
      if (RotateToTargetConditions())
        direction = _playerTargetHolder.LookDirectionToTarget;

      _playerRotator.RotateTowardsDirection(direction);
    }

    private bool RotateToTargetConditions() =>
      _playerTargetHolder.HasTarget && _backpackStorage.IsFull == false;
  }
}