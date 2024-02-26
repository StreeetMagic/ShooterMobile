using Infrastructure.Services.Inputs;
using UnityEngine;
using Zenject;

namespace Players
{
  public class PlayerInputHandler : ITickable

  {
    private readonly IInputService _inputService;
    private PlayerMover _mover;

    public PlayerInputHandler(IInputService inputService)
    {
      _inputService = inputService;
    }

    public void Init(PlayerMover mover)
    {
      _mover = mover;
    }

    private Vector3 GetDirection()
    {
      Vector2 directionXY = _inputService.MoveDirection;

      return new Vector3(directionXY.x, 0, directionXY.y);
    }

    public void Tick()
    {
      Debug.Log("Тикаю");
    }
  }
}