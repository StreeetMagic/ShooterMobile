using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetHolders;
using UnityEngine;

namespace Gameplay.Characters.Players.Rotators
{
  public class PlayerRotatorController
  {
    private TargetHolder _targetHolder;
    private PlayerRotator _playerRotator;
    private PlayerFactory _playerFactory;

    public PlayerRotatorController(PlayerFactory playerFactory, TargetHolder targetHolder)
    {
      _playerFactory = playerFactory;
      _targetHolder = targetHolder;

      _playerFactory.Created += OnCreated;
    }

    private void OnCreated(Player player)
    {
      _playerRotator = player.GetComponentInChildren<PlayerRotator>();

      _playerFactory.Created -= OnCreated;
    }

    public void RotateTowardsDirection(Vector3 direction)
    {
      if (_targetHolder.HasTarget)
        direction = _targetHolder.DirectionToTarget;

      _playerRotator.RotateTowardsDirection(direction);
    }
  }
}