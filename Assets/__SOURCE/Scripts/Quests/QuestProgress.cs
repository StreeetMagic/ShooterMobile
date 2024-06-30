using System;
using System.Collections.Generic;
using Quests.Subquests;

namespace Quests
{
  [Serializable]
  public class QuestProgress
  {
    public QuestId Id;
    public QuestState State;
    public List<SubQuestProgress> SubQuests;

    public QuestProgress(QuestId id, QuestState state, List<SubQuestProgress> subQuests)
    {
      Id = id;
      State = state;
      SubQuests = subQuests;
    }
  }
}