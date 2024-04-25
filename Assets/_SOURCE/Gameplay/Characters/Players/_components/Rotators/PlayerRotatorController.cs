using DataRepositories.BackpackStorages;
using Gameplay.Characters.Players._components.Factories;
using Gameplay.Characters.Players._components.TargetHolders;
using UnityEngine;

namespace Gameplay.Characters.Players._components.Rotators
{
  public class PlayerRotatorController
  {
    private readonly PlayerProvider _playerProvider;
    private readonly BackpackStorage _backpackStorage;

    public PlayerRotatorController(PlayerProvider playerProvider, BackpackStorage backpackStorage)
    {
      _playerProvider = playerProvider;
      _backpackStorage = backpackStorage;
    }

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private PlayerRotator PlayerRotator => _playerProvider.PlayerRotator;

    public void RotateTowardsDirection(Vector3 direction)
    {
      if (RotateToTargetConditions())
        direction = PlayerTargetHolder.LookDirectionToTarget;

      PlayerRotator.RotateTowardsDirection(direction);
    }

    private bool RotateToTargetConditions() =>
      PlayerTargetHolder.HasTarget && _backpackStorage.IsFull == false;
  }
}