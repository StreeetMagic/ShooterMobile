﻿using System;
using System.Collections;
using UnityEngine;

namespace _Infrastructure.CoroutineRunners
{
  public interface ICoroutineRunner : IDisposable
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
    void StopCoroutine(Coroutine coroutine);
    void StopAllCoroutines();
  }
}