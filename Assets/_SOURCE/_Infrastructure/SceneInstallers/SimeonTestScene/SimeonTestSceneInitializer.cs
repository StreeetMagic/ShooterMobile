using Projects;
using SceneInstallers.GameLoop;
using Scenes;

namespace SceneInstallers.SimeonTestScene
{
  public class SimeonTestSceneInitializer : GameLoopBaseInitializer
  {
    protected override void EnterScene()
    {
      SceneLoader.Load(SceneId.SimeonTestScene.ToString());
    }
  }
}