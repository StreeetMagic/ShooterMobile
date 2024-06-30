using System.Collections.Generic;
using Infrastructure.Utilities;
using Quests.Subquests;
using RewardServices;

namespace Quests
{
  public class Quest
  {
    private readonly RewardService _rewardService;

    public Quest(QuestState state, QuestConfig config,
      List<SubQuest> subQuests, RewardService rewardService, int index)
    {
      Config = config;
      _rewardService = rewardService;

      State = new ReactiveProperty<QuestState>(state);

      SubQuests = subQuests;

      foreach (SubQuest subQuest in subQuests)
        subQuest.Completed += OnSubQuestCompleted;

      Index = index;
    }

    public QuestConfig Config { get; }
    public ReactiveProperty<QuestState> State { get; }
    public List<SubQuest> SubQuests { get; }
    public int Index { get; }

    public void GainReward()
    {
      State.Value = QuestState.RewardTaken;
      _rewardService.OnRewardGain(Config.Reward);
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