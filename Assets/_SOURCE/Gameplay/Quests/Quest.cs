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
      Config = config;
      _rewardService = rewardService;

      State = new ReactiveProperty<QuestState>(state);

      SubQuests = subQuests;

      foreach (SubQuest subQuest in subQuests)
        subQuest.Completed += OnSubQuestCompleted;
    }

    public QuestConfig Config { get; }
    public ReactiveProperty<QuestState> State { get; }
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