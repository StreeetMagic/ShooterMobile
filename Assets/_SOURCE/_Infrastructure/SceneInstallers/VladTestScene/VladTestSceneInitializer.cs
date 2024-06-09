using Projects;
using SceneInstallers.GameLoop;
using Scenes;

namespace SceneInstallers.VladTestScene
{
  public class VladTestSceneInitializer : GameLoopBaseInitializer
  {
    protected override void EnterScene()
    {
      SceneLoader.Load(SceneId.VladTestScene.ToString());
    }
  }
}