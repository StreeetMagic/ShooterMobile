using System;
using System.Collections;
using Infrastructure.CoroutineRunners;
using UnityEngine;

namespace Infrastructure.Utilities
{
  public class CoroutineDecorator
  {
    private readonly Func<IEnumerator> _coroutineFunc;
    private readonly ICoroutineRunner _runner;
    private Coroutine _coroutine;

    public CoroutineDecorator(ICoroutineRunner runner, Func<IEnumerator> coroutineFunc)
    {
      _runner = runner;
      _coroutineFunc = coroutineFunc;
    }

    public bool IsRunning { get; private set; }

    public void Start(Action onComplete = null)
    {
      if (IsRunning && _coroutine != null)
        _runner.StopCoroutine(_coroutine);

      _coroutine = _runner.StartCoroutine(_coroutineFunc());
      IsRunning = true;
    }

    public void Stop()
    {
      if (_coroutine == null)
        return;

      _runner.StopCoroutine(_coroutine);
      IsRunning = false;
      _coroutine = null;
    }
  }
}