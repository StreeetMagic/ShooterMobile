using Configs.Resources.QuestConfigs;

namespace Quests
{
  public class Quest
  {
    public QuestState State { get; set; }
    public QuestConfig Config { get; set; }
  }
}