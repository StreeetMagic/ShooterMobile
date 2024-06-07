using Projects;
using SceneInstallers.GameLoop;

namespace SceneInstallers.VladTestScene
{
  public class VladTestSceneInitializer : GameLoopBaseInitializer
  {
    protected override void EnterScene()
    {
      SceneLoader.Load(ProjectConstants.Scenes.VladTestScene);
    }
  }
}