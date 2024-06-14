using System;
using Gameplay.RewardServices;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;

namespace Gameplay.Quests.Subquests
{
  public class SubQuest
  {
    private readonly SaveLoadService _saveLoadService;
    private readonly RewardService _rewardService;

    public SubQuest(int completedQuantity, QuestState state, int index,
      SaveLoadService saveLoadService, RewardService rewardService, SubQuestSetup setup, SubQuestContentSetup contentSetup)
    {
      CompletedQuantity = new ReactiveProperty<int>(completedQuantity);
      State = new ReactiveProperty<QuestState>(state);
      Index = index;
      Setup = setup;
      ContentSetup = contentSetup;
      
      _saveLoadService = saveLoadService;
      _rewardService = rewardService;

      CompletedQuantity.ValueChanged += OnCompletedQuantityChanged;
      State.ValueChanged += OnStateChanged;
    }

    public event Action<int> Completed;

    public int Index { get; }
    public ReactiveProperty<int> CompletedQuantity { get; }
    public ReactiveProperty<QuestState> State { get; }
    public SubQuestSetup Setup { get; }
    public SubQuestContentSetup ContentSetup { get; }

    private void OnCompletedQuantityChanged(int count)
    {
      _saveLoadService.SaveProgress();

      if (count >= Setup.Quantity)
        State.Value = QuestState.RewardReady;
    }

    private void OnStateChanged(QuestState state)
    {
      _saveLoadService.SaveProgress();

      if (state == QuestState.RewardTaken)
      {
        Completed?.Invoke(Index);
        _rewardService.OnSubQuestCompleted(Setup.Reward);
      }
    }
  }
}