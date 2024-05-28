using System;
using System.Collections;
using _Infrastructure.CoroutineRunners;
using _Infrastructure.Projects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Infrastructure.SceneLoaders
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
      //DOTween.KillAll();
      _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
    }

    public void Load(Action onLoaded = null)
    {
      _coroutineRunner.StartCoroutine(LoadScene(ProjectConstants.Scenes.Initial, onLoaded));
    }

    private IEnumerator LoadScene(string nextScene, Action onLoaded)
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