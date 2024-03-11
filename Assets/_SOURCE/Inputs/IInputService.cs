using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
  public interface IInputService
  {
    Vector2 MoveDirection { get; }
    Vector2 MoveDirectionFloatingJoystick { get; set; }
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
    }

    public Vector2 MoveDirection =>
      MoveDirectionFloatingJoystick != Vector2.zero
        ? MoveDirectionFloatingJoystick
        : _move.ReadValue<Vector2>();

    public Vector2 MoveDirectionFloatingJoystick { get; set; }
  }
}