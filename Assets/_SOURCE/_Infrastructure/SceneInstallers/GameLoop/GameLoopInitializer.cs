using Projects;
using Scenes;

namespace SceneInstallers.GameLoop
{
  public class GameLoopInitializer : GameLoopBaseInitializer
  {
    protected override void EnterScene()
    {
      SceneLoader.Load(SceneId.CoreDust.ToString());
    }
  }
}