using System;
using UnityEngine.Serialization;

namespace Gameplay.Quests.Subquests
{
  [Serializable]
  public class SubQuestProgress
  {
    [FormerlySerializedAs("typeId")] [FormerlySerializedAs("Type")] public SubQuestId id;
    public int CompletedQuantity;
    public QuestState State;

    public SubQuestProgress(SubQuestId id, int completedQuantity, QuestState state)
    {
      this.id = id;
      CompletedQuantity = completedQuantity;
      State = state;
    }
  }
}