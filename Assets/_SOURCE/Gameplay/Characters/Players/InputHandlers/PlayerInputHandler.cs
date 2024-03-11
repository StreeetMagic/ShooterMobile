using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.Movers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.TargetHolders;
using Inputs;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.InputHandlers
{
  public class PlayerInputHandler : ITickable
  {
    private readonly IInputService _inputService;
    private readonly PlayerProvider _playerProvider;

    public PlayerInputHandler(IInputService inputService,
      PlayerProvider playerProvider)
    {
      _inputService = inputService;
      _playerProvider = playerProvider;
    }

    private PlayerRotatorController RotatorController => _playerProvider.PlayerRotatorController;
    private PlayerMover Mover => _playerProvider.PlayerMover;

    public bool CanMove { get; private set; } = true;

    public void EnableMove()
    {
      CanMove = true;
      Debug.Log("можно двигаться");
    }

    public void DisableMove()
    {
      CanMove = false;
      Debug.Log("нельзя двигаться");
    }
    
    public void Tick()
    {
      if (CanMove == false)
        return;

      Vector3 moveDirection = GetDirection();

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