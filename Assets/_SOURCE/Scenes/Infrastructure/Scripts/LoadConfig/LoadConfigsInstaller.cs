using Zenject.Source.Install;

namespace SceneInstallers.LoadConfig
{
  public class LoadConfigsInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<LoadConfigsInitializer>().FromInstance(GetComponent<LoadConfigsInitializer>()).AsSingle().NonLazy();
    }
  }
}