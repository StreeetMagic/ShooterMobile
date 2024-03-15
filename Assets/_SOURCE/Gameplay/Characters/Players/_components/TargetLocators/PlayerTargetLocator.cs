using System;
using Gameplay.Characters.Enemies.TargetTriggers;
using UnityEngine;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerTargetLocator : MonoBehaviour
  {
    public event Action<TargetTrigger> TargetLocated;
    public event Action<TargetTrigger> TargetLost;

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out TargetTrigger targetTrigger))
      {
        TargetLocated?.Invoke(targetTrigger);
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.TryGetComponent(out TargetTrigger targetTrigger))
      {
        TargetLost?.Invoke(targetTrigger);
      }
    }
  }
}