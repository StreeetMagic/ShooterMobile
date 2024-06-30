using System;
using UnityEngine;

namespace Characters.Players._components.Animators
{
  public class PlayerAnimatorEventHandler : MonoBehaviour
  {
    public event Action Shot;

    public void Shoot()
    {
      Shot?.Invoke();
    }
  }
}