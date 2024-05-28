using Gameplay.Quests;
using UserIntefaces;
using Zenject.Source.Factories;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows
{
  public class QuestWindow : Window
  {
    public class Factory : PlaceholderFactory<Quest, QuestConfig, QuestWindow>
    {
    }
  }
}