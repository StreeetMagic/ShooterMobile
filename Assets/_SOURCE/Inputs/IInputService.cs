﻿using System;
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
  }

  public class InputService : IInputService
  {
    private Controls _controls;

    private InputAction _move;
    private InputAction _restart;
    private InputAction _deleteSaves;

    public InputService()
    {
      _controls = new Controls();

      _move = _controls.Player.Move;
      _move.Enable();

      _restart = _controls.Debug.Restart;
      _restart.Enable();
      _restart.performed += _ => Restart?.Invoke();

      _deleteSaves = _controls.Debug.DeleteSaves;
      _deleteSaves.Enable();
      _deleteSaves.performed += _ => DeleteSaves?.Invoke();
    }

    public event Action Restart;
    public event Action DeleteSaves;

    public Vector2 MoveDirection =>
      MoveDirectionFloatingJoystick != Vector2.zero
        ? MoveDirectionFloatingJoystick
        : _move.ReadValue<Vector2>();

    public Vector2 MoveDirectionFloatingJoystick { get; set; }
  }
}