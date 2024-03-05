using System.Collections;
using UnityEngine;

namespace Infrastructure.CoroutineRunners
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
    void StopCoroutine(Coroutine coroutine);
  }
}