using Infrastructure.UserIntefaces;
using Quests;
using Zenject.Source.Factories;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class QuestWindow : Window
  {
    public class Factory : PlaceholderFactory<Quest, QuestWindow>
    {
    }
  }
}