using SceneInstallers.GameLoop;
using Scenes;

namespace SceneInstallers.VladTestScene
{
  public class ValeraTestSceneInitializer : GameLoopBaseInitializer
  {
    protected override void EnterScene()
    {
      SceneLoader.Load(SceneId.ValeraTestScene.ToString());
    }
  }
}