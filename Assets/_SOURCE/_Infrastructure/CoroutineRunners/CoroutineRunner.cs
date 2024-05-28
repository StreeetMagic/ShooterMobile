using UnityEngine;

namespace _Infrastructure.CoroutineRunners
{
  public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
  {
    public void Dispose()
    {
      StopAllCoroutines();
    }
  }
}