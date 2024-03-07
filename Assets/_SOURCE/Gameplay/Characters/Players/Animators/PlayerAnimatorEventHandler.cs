using System;
using UnityEngine;

public class PlayerAnimatorEventHandler : MonoBehaviour
{
  public event Action Shot;

  public void Shoot()
  {
    Shot?.Invoke();
  }
}