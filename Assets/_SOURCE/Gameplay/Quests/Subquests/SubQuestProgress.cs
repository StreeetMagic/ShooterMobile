using System;
using Configs.Resources.QuestConfigs.SubQuestConfigs.Scripts;

namespace Quests.Subquests
{
  [Serializable]
  public class SubQuestProgress
  {
    public SubQuestType Type;
    public int CompletedQuantity;
    public QuestState State;

    public SubQuestProgress(SubQuestType type, int completedQuantity, QuestState state)
    {
      Type = type;
      CompletedQuantity = completedQuantity;
      State = state;
    }
  }
}