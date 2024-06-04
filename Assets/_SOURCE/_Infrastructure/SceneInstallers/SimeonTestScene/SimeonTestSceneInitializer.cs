using Projects;

namespace SceneInstallers.GameLoop
{
  public class SimeonTestSceneInitializer : GameLoopBaseInitializer
  {
    protected override void EnterScene()
    {
      SceneLoader.Load(ProjectConstants.Scenes.SimeonTestScene);
    }
  }
}