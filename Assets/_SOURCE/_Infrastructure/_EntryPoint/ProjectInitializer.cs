using _Infrastructure.Projects;
using _Infrastructure.SceneLoaders;
using UnityEngine;
using Zenject;

namespace _Infrastructure._EntryPoint
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