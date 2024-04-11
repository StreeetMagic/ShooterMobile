using Configs.Resources.QuestConfigs;

namespace Quests
{
  public class Quest
  {
    public Quest(QuestState state, QuestConfig config)
    {
      State = state;
      Config = config;
    }

    public QuestState State { get; set; }
    public QuestConfig Config { get; set; }
  }
}