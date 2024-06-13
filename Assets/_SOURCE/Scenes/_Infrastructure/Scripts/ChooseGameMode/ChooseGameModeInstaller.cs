using Zenject.Source.Install;

namespace Scenes._Infrastructure.Scripts.ChooseGameMode
{
  public class ChooseGameModeInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<ChooseGameModeInitializer>().FromInstance(GetComponent<ChooseGameModeInitializer>()).AsSingle().NonLazy();
    }
  }
}