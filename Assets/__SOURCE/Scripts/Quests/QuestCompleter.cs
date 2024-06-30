using System;
using Gameplay.Characters.Enemies;
using Gameplay.Quests.Subquests;

namespace Gameplay.Quests
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