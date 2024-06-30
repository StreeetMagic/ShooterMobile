using System;
using Characters.Enemies;
using Quests.Subquests;

namespace Quests
{
  public class QuestCompleter
  {
    private readonly QuestStorage _storage;

    public QuestCompleter(QuestStorage storage)
    {
      _storage = storage;
    }

    //TODO: refactor
    public void OnEnemyKilled(EnemyTypeId enemyId)
    {
      foreach (Quest quest in _storage.GetAllQuests())
      {
        foreach (SubQuest subQuest in quest.SubQuests)
        {
          if (subQuest.State.Value != QuestState.Activated)
            continue;

          switch (subQuest.ContentSetup.Id)
          {
            case SubQuestId.Unknown:
              throw new Exception("Unknown sub quest");

            case SubQuestId.DefuseBomb:
              continue;

            default:

              if (enemyId == EnemyTypeId.Unknown)
                throw new ArgumentOutOfRangeException(nameof(enemyId), enemyId, null);

              subQuest.CompletedQuantity.Value++;

              break;
          }
        }
      }
    }
  }
}