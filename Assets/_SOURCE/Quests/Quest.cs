using System.Collections.Generic;
using Configs.Resources.QuestConfigs;
using DataRepositories.Quests;
using Infrastructure.Utilities;

namespace Quests
{
  public class Quest
  {
    public Quest(QuestState state, QuestConfig config, List<SubQuest> subQuests)
    {
      State = new ReactiveProperty<QuestState>(state);
      Config = config;
      SubQuests = subQuests;
    }

    public ReactiveProperty<QuestState> State { get; set; }
    public QuestConfig Config { get; set; }
    public List<SubQuest> SubQuests { get; set; }
  }
}