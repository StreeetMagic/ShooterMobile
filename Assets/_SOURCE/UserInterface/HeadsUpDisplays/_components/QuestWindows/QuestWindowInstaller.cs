using Infrastructure.AssetProviders;
using Quests.Subquests;
using UserInterface.HeadsUpDisplays.QuestWindows;
using UserInterface.HeadsUpDisplays.QuestWindows.SubQuestSlots;
using Zenject;
using Zenject.Source.Install;

public class QuestWindowInstaller : MonoInstaller
{
  public QuestWindow QuestWindow;

  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<QuestWindow>().FromInstance(QuestWindow).AsSingle();
  }
}