﻿using System;
using System.Collections;
using Infrastructure.CoroutineRunners;
using Infrastructure.Games;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneLoaders
{
  public class SceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader( ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public event Action<string> SceneLoaded;

    public void Load(string name, Action<string> onLoaded = null)
    {
      //DOTween.KillAll();
      _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
    }

    public void Load(Action<string> onLoaded = null)
    {
      _coroutineRunner.StartCoroutine(LoadScene(Constants.Scenes.Initial, onLoaded));
    }

    private IEnumerator LoadScene(string nextScene, Action<string> onLoaded)
    {
      // if (SceneManager.GetActiveScene().name == nextScene)
      // {
      //     onLoaded?.Invoke(nextScene);
      //     SceneLoaded?.Invoke(nextScene);
      //     yield break;
      // }

      AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextScene);
      asyncOperation.allowSceneActivation = true;

      while (asyncOperation.isDone == false)
      {
        yield return null;
      }

      onLoaded?.Invoke(nextScene);
      SceneLoaded?.Invoke(nextScene);
    }
  }
}