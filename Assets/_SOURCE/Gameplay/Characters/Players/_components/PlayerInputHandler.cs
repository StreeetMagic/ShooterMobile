using Gameplay.Characters.Players.Rotators;
using Inputs;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerInputHandler
  {
    private readonly InputService _inputService;
    private readonly PlayerRotatorController _rotatorController;
    private readonly PlayerMover _mover;

    public PlayerInputHandler(InputService inputService,
      PlayerRotatorController rotatorController, PlayerMover mover)
    {
      _inputService = inputService;
      _rotatorController = rotatorController;
      _mover = mover;
    }

    public void ReadInput()
    {
      Vector3 moveDirection = GetDirection();

      if (_mover == null)
        return;

      if (_rotatorController == null)
        return;

      _mover.Move(moveDirection);

      _rotatorController.RotateTowardsDirection(moveDirection);
    }

    private Vector3 GetDirection()
    {
      Vector2 directionXY = _inputService.MoveDirection;

      return new Vector3(directionXY.x, 0, directionXY.y);
    }
  }
}