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

    private PlayerMover _mover;
    private PlayerRotator _rotator;

    public PlayerInputHandler(IInputService inputService, PlayerFactory playerFactory)
    {
      Debug.Log("Я кекнул");
      
      _inputService = inputService;

      _playerFactory = playerFactory;
      playerFactory.Created += OnPlayerCreated;
    }

    public void Tick()
    {
      if (_inputService.CanMove == false)
        return;

      Vector3 direction = GetDirection();

      _mover.Move(direction);
      _rotator.RotateTowardsDirection(direction);
    }

    private void OnPlayerCreated(Player player)
    {
      _mover = player.GetComponent<PlayerMover>();
      _rotator = player.GetComponent<PlayerRotator>();
      _playerFactory.Created -= OnPlayerCreated;
    }

    private Vector3 GetDirection()
    {
      Vector2 directionXY = _inputService.MoveDirection;

      return new Vector3(directionXY.x, 0, directionXY.y);
    }
  }
}