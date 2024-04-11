using System;
using Quests;

namespace Infrastructure.PersistentProgresses
{
  [Serializable]
  public class QuestProgress
  {
    public QuestId Id;
    public QuestState State;

    public QuestProgress(QuestId id, QuestState state)
    {
      Id = id;
      State = state;
    }
  }
}