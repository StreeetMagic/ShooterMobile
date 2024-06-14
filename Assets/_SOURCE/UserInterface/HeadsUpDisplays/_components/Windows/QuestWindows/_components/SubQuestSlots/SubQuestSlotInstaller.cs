using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using Zenject;
using Zenject.Source.Install;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows._components.SubQuestSlots
{
  public class SubQuestSlotInstaller : MonoInstaller
  {
    public SubQuestSlot SubQuestSlot;

    [Inject] private SubQuest _subQuest;

    public override void InstallBindings()
    {
      Container.Bind<SubQuestSlot>().FromInstance(SubQuestSlot).AsSingle();
      
      Container.Bind<SubQuest>().FromInstance(_subQuest).AsSingle();
      Container.Bind<SubQuestSetup>().FromInstance(_subQuest.Setup).AsSingle();
    }
  }
}