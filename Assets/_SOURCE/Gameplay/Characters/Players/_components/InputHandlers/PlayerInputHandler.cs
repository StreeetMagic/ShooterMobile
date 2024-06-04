using Gameplay.Characters.Players.Movers;
using Gameplay.Characters.Players.Rotators;
using Inputs;
using UnityEngine;
using Zenject;
using Zenject.Source.Runtime;

namespace Gameplay.Characters.Players.InputHandlers
{
  public class PlayerInputHandler : ITickable
  {
    private readonly IInputService _inputService;
    private readonly PlayerProvider _playerProvider;

    public PlayerInputHandler(IInputService inputService,
      PlayerProvider playerProvider, TickableManager tickableManager)
    {
      _inputService = inputService;
      _playerProvider = playerProvider;

      tickableManager.Add(this);
    }

    private PlayerRotatorController RotatorController => _playerProvider.PlayerRotatorController;
    private PlayerMover Mover => _playerProvider.PlayerMover;

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

      if (Mover == null)
        return;
      
      if (RotatorController == null)
        return;
      
      Mover.Move(moveDirection);

      RotatorController.RotateTowardsDirection(moveDirection);
    }

    private Vector3 GetDirection()
    {
      Vector2 directionXY = _inputService.MoveDirection;

      return new Vector3(directionXY.x, 0, directionXY.y);
    }
  }
}