using Configs.Resources.QuestConfigs;
using Infrastructure.UserIntefaces;
using Quests;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class QuestWindow : Window
  {
    public QuestConfig QuestConfig { get; set; }
    public Quest Quest { get; set; }
  }
}