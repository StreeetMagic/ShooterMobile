using Configs.Resources.QuestConfigs.Scripts;
using Configs.Resources.QuestConfigs.SubQuestConfigs.Scripts;
using Quests.Subquests;
using Zenject;
using Zenject.Source.Install;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components.SubQuestSlots
{
  public class SubQuestSlotInstaller : MonoInstaller
  {
    public SubQuestSlot SubQuestSlot;

    private SubQuest _subQuest;

    [Inject]
    public void Construct(SubQuest subQuest)
    {
      _subQuest = subQuest;
    }

    public override void InstallBindings()
    {
      Container.Bind<SubQuest>().FromInstance(_subQuest).AsSingle();
      Container.Bind<SubQuestSlot>().FromInstance(SubQuestSlot).AsSingle();
      Container.Bind<SubQuestConfig>().FromInstance(_subQuest.Setup.Config).AsSingle();
      Container.Bind<SubQuestSetup>().FromInstance(_subQuest.Setup).AsSingle();
    }
  }
}