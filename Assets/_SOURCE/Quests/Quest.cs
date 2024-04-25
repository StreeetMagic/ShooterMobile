using System.Collections.Generic;
using Configs.Resources.QuestConfigs.Scripts;
using Gameplay.RewardServices;
using Infrastructure.Utilities;
using Quests.Subquests;

namespace Quests
{
  public class Quest
  {
    private readonly RewardService _rewardService;

    public Quest(QuestState state, QuestConfig config,
      List<SubQuest> subQuests, RewardService rewardService)
    {
      State = new ReactiveProperty<QuestState>(state);
      Config = config;
      SubQuests = subQuests;
      _rewardService = rewardService;

      foreach (SubQuest subQuest in subQuests)
      {
        subQuest.Completed += OnSubQuestCompleted;
      }
    }

    public ReactiveProperty<QuestState> State { get; }
    public QuestConfig Config { get; }
    public List<SubQuest> SubQuests { get; }

    public void GainReward()
    {
      State.Value = QuestState.RewardTaken;
      _rewardService.OnQuestCompleted(Config.Reward);
    }

    private void OnSubQuestCompleted(int index)
    {
      if (index >= SubQuests.Count - 1)
      {
        State.Value = QuestState.RewardReady;

        foreach (SubQuest subQuest in SubQuests)
        {
          subQuest.Completed -= OnSubQuestCompleted;
        }
      }
      else
      {
        SubQuests[index + 1].State.Value = QuestState.Activated;
      }
    }
  }
}