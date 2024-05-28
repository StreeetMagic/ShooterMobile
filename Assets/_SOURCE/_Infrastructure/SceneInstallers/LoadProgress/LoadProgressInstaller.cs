using Zenject.Source.Install;

public class LoadProgressInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<LoadProgressInitializer>().FromInstance(GetComponent<LoadProgressInitializer>()).AsSingle().NonLazy();
  }
}