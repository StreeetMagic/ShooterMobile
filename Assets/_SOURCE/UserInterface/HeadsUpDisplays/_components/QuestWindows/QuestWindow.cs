using Infrastructure.UserIntefaces;
using Quests;
using Zenject;
using Zenject.Source.Factories;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class QuestWindow : Window
  {
    [Inject]
    public void Construct(Quest quest)
    {
      Quest = quest;
    }

    public Quest Quest { get; private set; }

    public class Factory : PlaceholderFactory<Quest, QuestWindow>
    {
    }
  }
}