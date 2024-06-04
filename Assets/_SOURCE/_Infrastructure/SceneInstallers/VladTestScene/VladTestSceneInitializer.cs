using Projects;

namespace SceneInstallers.GameLoop
{
  public class VladTestSceneInitializer : GameLoopBaseInitializer
  {
    protected override void EnterScene()
    {
      SceneLoader.Load(ProjectConstants.Scenes.VladTestScene);
    }
  }
}