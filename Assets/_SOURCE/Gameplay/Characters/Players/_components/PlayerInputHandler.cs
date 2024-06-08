using Gameplay.Characters.Players.Rotators;
using Inputs;
using UnityEngine;
using Zenject;
using Zenject.Source.Runtime;

namespace Gameplay.Characters.Players
{
  public class PlayerInputHandler : ITickable
  {
    private readonly IInputService _inputService;
    private readonly PlayerRotatorController _rotatorController;
    private readonly PlayerMover _mover;

    public PlayerInputHandler(IInputService inputService,
      PlayerRotatorController rotatorController, PlayerMover mover)
    {
      _inputService = inputService;
      _rotatorController = rotatorController;
      _mover = mover;
    }

    public bool CanMove { get; private set; } = true;
    public bool IsMoving { get; private set; }

    public void EnableMove()
    {
      CanMove = true;
    }

    public void DisableMove()
    {
      CanMove = false;
    }

    public void Tick()
    {
      if (CanMove == false)
        return;

      Vector3 moveDirection = GetDirection();

      IsMoving = moveDirection != Vector3.zero;

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