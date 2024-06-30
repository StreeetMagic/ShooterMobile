using Zenject.Source.Install;

namespace Scenes._Infrastructure.Scripts.LoadProgress
{
  public class LoadProgressInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<LoadProgressInitializer>().FromInstance(GetComponent<LoadProgressInitializer>()).AsSingle().NonLazy();
    }
  }
}