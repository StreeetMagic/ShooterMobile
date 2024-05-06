using Gameplay.Characters.Players.ActorUserIntefaces.QuestPointers;
using Zenject.Source.Install;

public class QuestPointerInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    Container.Bind<QuestTargetProvider>().AsSingle();
  }
}