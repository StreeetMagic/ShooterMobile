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

      foreach (SubQuest subQuest in subQuests)
      {
        subQuest.Completed += OnSubQuestCompleted;
      }
    }

    private void OnSubQuestCompleted(int index)
    {
      if (index >= SubQuests.Count - 1)
      {
        State.Value = QuestState.RewardReady;
      }
      else
      {
        SubQuests[index + 1].State.Value = QuestState.Activated;
      }
    }

    public ReactiveProperty<QuestState> State { get; }
    public QuestConfig Config { get; }
    public List<SubQuest> SubQuests { get; }
  }
}