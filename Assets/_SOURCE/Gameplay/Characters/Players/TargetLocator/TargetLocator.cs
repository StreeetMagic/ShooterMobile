using System;
using UnityEngine;

public class TargetLocator : MonoBehaviour
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