using Quests;
using UserInterface.HeadsUpDisplays.QuestWindows;
using Zenject;
using Zenject.Source.Install;

public class QuestWindowInstaller : MonoInstaller
{
  public QuestWindow QuestWindow;

  private Quest _quest;
  
  [Inject]
  public void Construct(Quest quest)
  {
    _quest = quest;
  }

  public override void InstallBindings()
  {
    Container.Bind<Quest>().FromInstance(_quest).AsSingle();
    Container.Bind<QuestWindow>().FromInstance(QuestWindow).AsSingle();
  }
}