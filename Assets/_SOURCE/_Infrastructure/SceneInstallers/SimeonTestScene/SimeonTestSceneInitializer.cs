using Projects;
using SceneInstallers.GameLoop;

namespace SceneInstallers.SimeonTestScene
{
  public class SimeonTestSceneInitializer : GameLoopBaseInitializer
  {
    protected override void EnterScene()
    {
      SceneLoader.Load(ProjectConstants.Scenes.SimeonTestScene);
    }
  }
}