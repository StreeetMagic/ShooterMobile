using Gameplay.Quests;
using Zenject;
using Zenject.Source.Install;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows
{
  public class QuestWindowInstaller : MonoInstaller
  {
    [Inject] private Quest _quest;
    [Inject] private QuestId _id;

    public override void InstallBindings()
    {
      Container.Bind<Quest>().FromInstance(_quest).AsSingle();
      Container.Bind<QuestId>().FromInstance(_id).AsSingle(); 
      Container.Bind<QuestWindow>().FromInstance(GetComponent<QuestWindow>()).AsSingle();
    }
  }
}