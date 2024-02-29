using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.DependencyInjection.ZenjectFixes
{
  public static class StartSceneController 
  {
    [RuntimeInitializeOnLoadMethod]
    private static void onAppLoaded()
    {
      Scene scene = SceneManager.GetActiveScene();

      if (scene.buildIndex != 0)
        SceneManager.LoadScene(0);
    }
  }
}