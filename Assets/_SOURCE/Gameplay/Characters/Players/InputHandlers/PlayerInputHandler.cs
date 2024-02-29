using Gameplay.Characters.Players.PlayerFactories;
using Inputs;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Movers
{
  public class PlayerInputHandler : ITickable
  {
    private readonly IInputService _inputService;
    private readonly PlayerFactory _playerFactory;
    private readonly TargetHolder _targetHolder;

    private PlayerMover _mover;
    private PlayerRotatorController _rotatorController;

    public PlayerInputHandler(IInputService inputService, PlayerFactory playerFactory, TargetHolder targetHolder, PlayerRotatorController rotatorController)
    {
      _inputService = inputService;
      _rotatorController = rotatorController;

      _targetHolder = targetHolder;
      _playerFactory = playerFactory;
      playerFactory.Created += OnPlayerCreated;
    }

    public void Tick()
    {
      if (_inputService.CanMove == false)
        return;

      Vector3 moveDirection = GetDirection();

      _mover.Move(moveDirection);

      _rotatorController.RotateTowardsDirection(moveDirection);
    }

    private void OnPlayerCreated(Player player)
    {
      _mover = player.GetComponent<PlayerMover>();
      _playerFactory.Created -= OnPlayerCreated;
    }

    private Vector3 GetDirection()
    {
      Vector2 directionXY = _inputService.MoveDirection;

      return new Vector3(directionXY.x, 0, directionXY.y);
    }
  }
}