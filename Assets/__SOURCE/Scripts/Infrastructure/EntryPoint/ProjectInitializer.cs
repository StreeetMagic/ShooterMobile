using Infrastructure.SceneLoaders;
using Scripts;
using UnityEngine;
using Zenject;

namespace Infrastructure.EntryPoint
{
  public class ProjectInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;

    public void Initialize()
    {
      _sceneLoader.Load(SceneId.ChooseGameMode);
    }
  }
}