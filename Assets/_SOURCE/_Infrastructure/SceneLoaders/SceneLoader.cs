﻿using System;
using System.Collections;
using CoroutineRunners;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoaders
{
  public class SceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public event Action<string> SceneLoaded;

    public void Load(string name, Action onLoaded = null)
    {
      _coroutineRunner.StartCoroutine(LoadSceneAsync(name, onLoaded));
    }

    // public void Load(Action onLoaded = null)
    // {
    //   _coroutineRunner.StartCoroutine(LoadSceneAsync(ProjectConstants.Scenes.Initial, onLoaded));
    // }

    private IEnumerator LoadSceneAsync(string nextScene, Action onLoaded)
    {
      AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextScene);

      if (asyncOperation != null)
      {
        asyncOperation.allowSceneActivation = true;

        while (asyncOperation.isDone == false)
        {
          yield return null;
        }
      }

      onLoaded?.Invoke();
      SceneLoaded?.Invoke(nextScene);
    }
  }
}