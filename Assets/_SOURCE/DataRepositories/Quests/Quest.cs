using System.Collections.Generic;
using Configs.Resources.QuestConfigs;
using DataRepositories.Quests;

namespace Quests
{
  public class Quest
  {
    public Quest(QuestState state, QuestConfig config, List<SubQuest> subQuests)
    {
      State = state;
      Config = config;
      SubQuests = subQuests;
    }

    public QuestState State { get; set; }
    public QuestConfig Config { get; set; }
    public List<SubQuest> SubQuests { get; set; }
  }
}