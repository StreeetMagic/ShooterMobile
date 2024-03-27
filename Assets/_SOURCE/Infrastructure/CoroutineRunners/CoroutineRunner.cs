using UnityEngine;

namespace Infrastructure.CoroutineRunners
{
  public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
  {
    public void Dispose()
    {
      StopAllCoroutines();
    }
  }
}