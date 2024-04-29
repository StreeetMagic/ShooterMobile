using System;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters
{
  public class PlayerMoveSpeed : MonoBehaviour
  {
    private Vector3 _previousPosition;

    public ReactiveProperty<float> CurrentMoveSpeed { get; } = new(0f);

    private void OnEnable()
    {
      _previousPosition = transform.position;
    }

    private void Update()
    {
      if (_previousPosition != transform.position)
      {
        float speed = (transform.position - _previousPosition).magnitude / Time.fixedDeltaTime;

        if (Math.Abs(speed - CurrentMoveSpeed.Value) > .01f)
          CurrentMoveSpeed.Value = speed;
      }
      else
      {
        if (CurrentMoveSpeed.Value > 0f)
          CurrentMoveSpeed.Value = 0f;
      }

      _previousPosition = transform.position;

    }
  }
}