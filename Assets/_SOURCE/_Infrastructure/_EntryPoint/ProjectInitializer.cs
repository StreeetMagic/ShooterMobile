using Projects;
using SceneLoaders;
using UnityEngine;
using Zenject;

namespace _EntryPoint
{
  public class ProjectInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;

    public void Initialize()
    {
      _sceneLoader.Load(ProjectConstants.Scenes.LoadConfigs);
    }
  }
}