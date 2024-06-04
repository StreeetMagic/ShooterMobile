using Projects;

namespace SceneInstallers.GameLoop
{
  public class GameLoopInitializer : GameLoopBaseInitializer
  {
    protected override void EnterScene()
    {
      SceneLoader.Load(ProjectConstants.Scenes.GameLoop);
    }
  }
}