using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
  public interface IInputService
  {
    Vector2 MoveDirection { get; }
    Vector2 MoveDirectionFloatingJoystick { get; set; }
    event Action Restart;
    event Action DeleteSaves;
    event Action OpenQuestWindow;
  }

  public class InputService : IInputService
  {
    private readonly InputAction _move;
    private readonly InputAction _restart;
    private readonly InputAction _deleteSaves;
    private readonly InputAction _openQuestWindow;

    public InputService()
    {
      var controls = new Controls();

      _move = controls.Player.Move;
      _move.Enable();

      _restart = controls.Debug.Restart;
      _restart.Enable();
      _restart.performed += _ => Restart?.Invoke();

      _deleteSaves = controls.Debug.DeleteSaves;
      _deleteSaves.Enable();
      _deleteSaves.performed += _ => DeleteSaves?.Invoke();

      _openQuestWindow = controls.Debug.OpenQuestWindow;
      _openQuestWindow.Enable();
      _openQuestWindow.performed += _ => OpenQuestWindow?.Invoke();
    }

    public event Action Restart;
    public event Action DeleteSaves;
    public event Action OpenQuestWindow;

    public Vector2 MoveDirection =>
      MoveDirectionFloatingJoystick != Vector2.zero
        ? MoveDirectionFloatingJoystick
        : _move.ReadValue<Vector2>();

    public Vector2 MoveDirectionFloatingJoystick { get; set; }
  }
}