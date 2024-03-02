using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
  public interface IInputService
  {
    Vector2 MoveDirection { get; }
    bool CanMove { get; }
    void EnableMove();
    void DisableMove();
  }

  public class InputService : IInputService
  {
    private Controls _controls;
    private InputAction _move;

    public InputService()
    {
      _controls = new Controls();
      _move = _controls.Player.Move;
      _move.Enable();
      CanMove = true;
    }

    public Vector2 MoveDirection => _move.ReadValue<Vector2>();
    public bool CanMove { get; private set; }

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
  }
}