using Gameplay.Quests;
using Infrastructure.UserIntefaces;
using Zenject.Source.Factories;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows
{
  public class QuestWindow : Window
  {
    public class Factory : PlaceholderFactory<Quest, QuestId, QuestWindow>
    {
    }
  }
}