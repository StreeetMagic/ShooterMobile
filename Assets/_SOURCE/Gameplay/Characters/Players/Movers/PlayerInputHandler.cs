using Infrastructure.Services.Inputs;
using UnityEngine;
using Zenject;

namespace Players
{
  public class PlayerInputHandler : ITickable
  {
    private readonly IInputService _inputService;
    private readonly PlayerFactory _playerFactory;

    private PlayerMover _mover;

    public PlayerInputHandler(IInputService inputService, PlayerFactory playerFactory)
    {
      _inputService = inputService;

      _playerFactory = playerFactory;
      playerFactory.Created += OnPlayerCreated;
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

    public void Tick()
    {
      if (_inputService.CanMove == false)
        return;

      Vector3 direction = GetDirection();

      _mover.Move(direction);
      _mover.RotateTowardsDirection(direction);
    }
  }
}