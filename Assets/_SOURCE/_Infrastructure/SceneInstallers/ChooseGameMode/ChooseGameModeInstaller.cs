using Zenject.Source.Install;

namespace _Infrastructure.SceneInstallers.ChooseGameMode
{
  public class ChooseGameModeInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<ChooseGameModeInitializer>().FromInstance(GetComponent<ChooseGameModeInitializer>()).AsSingle().NonLazy();
    }
  }
}