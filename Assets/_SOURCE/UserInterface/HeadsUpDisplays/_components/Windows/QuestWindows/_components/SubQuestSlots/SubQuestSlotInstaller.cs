using Configs.Resources.QuestConfigs.Scripts;
using Configs.Resources.QuestConfigs.SubQuestConfigs.Scripts;
using Quests.Subquests;
using Zenject;
using Zenject.Source.Install;

namespace UserInterface.HeadsUpDisplays.QuestWindows.SubQuestSlots
{
  public class SubQuestSlotInstaller : MonoInstaller
  {
    public SubQuestSlot SubQuestSlot;

    [Inject] private SubQuest _subQuest;

    public override void InstallBindings()
    {
      Container.Bind<SubQuestSlot>().FromInstance(SubQuestSlot).AsSingle();
      
      Container.Bind<SubQuest>().FromInstance(_subQuest).AsSingle();
      Container.Bind<SubQuestConfig>().FromInstance(_subQuest.Setup.Config).AsSingle();
      Container.Bind<SubQuestSetup>().FromInstance(_subQuest.Setup).AsSingle();
    }
  }
}