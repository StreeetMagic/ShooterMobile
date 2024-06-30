using Infrastructure.UserIntefaces;
using Quests;
using Zenject.Source.Factories;

namespace UserInterface.Windows.QuestWindows
{
  public class QuestWindow : Window
  {
    public class Factory : PlaceholderFactory<Quest, QuestId, QuestWindow>
    {
    }
  }
}