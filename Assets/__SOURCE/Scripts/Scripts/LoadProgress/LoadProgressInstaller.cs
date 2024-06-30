using Zenject.Source.Install;

namespace Scripts.LoadProgress
{
  public class LoadProgressInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<LoadProgressInitializer>().FromInstance(GetComponent<LoadProgressInitializer>()).AsSingle().NonLazy();
    }
  }
}