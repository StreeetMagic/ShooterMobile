using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetHolders;
using UnityEngine;

namespace Gameplay.Characters.Players.Rotators
{
  public class PlayerRotatorController
  {
    private readonly PlayerProvider _playerProvider;

    public PlayerRotatorController(PlayerProvider playerProvider)
    {
      _playerProvider = playerProvider;
    }

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private PlayerRotator PlayerRotator => _playerProvider.PlayerRotator;

    public void RotateTowardsDirection(Vector3 direction)
    {
      if (PlayerTargetHolder.HasTarget)
        direction = PlayerTargetHolder.DirectionToTarget;

      PlayerRotator.RotateTowardsDirection(direction);
    }
  }
}