using Inputs;
using UnityEngine;

namespace Characters.Players._components
{
  public class PlayerInputHandler
  {
    private readonly InputService _inputService;
    private readonly PlayerMover _mover;

    public PlayerInputHandler(InputService inputService,
      PlayerMover mover)
    {
      _inputService = inputService;
      _mover = mover;
    }

    public void ReadInput()
    {
      Vector3 moveDirection = GetDirection();

      if (_mover == null)
        return;

      _mover.Move(moveDirection);
    }

    public Vector3 GetDirection()
    {
      Vector2 directionXY = _inputService.MoveDirection;

      return new Vector3(directionXY.x, 0, directionXY.y);
    }
  }
}