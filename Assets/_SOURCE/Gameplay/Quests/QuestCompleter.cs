using System;
using Gameplay.Characters.Enemies;
using Gameplay.Quests.Subquests;
using Maps;

namespace Gameplay.Quests
{
  public class QuestCompleter
  {
    private readonly QuestStorage _storage;
    private readonly MapProvider _mapProvider;

    public QuestCompleter(QuestStorage storage, MapProvider mapProvider)
    {
      _storage = storage;
      _mapProvider = mapProvider;

      foreach (Quest quest in _storage.GetAllQuests())
      {
        foreach (SubQuest subQuest in quest.SubQuests)
        {
          subQuest.State.ValueChanged += state => OnSubQuestStateChanged(state, subQuest);

          OnSubQuestStateChanged(subQuest.State.Value, subQuest);
        }
      }
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

    private void OnSubQuestStateChanged(QuestState state, SubQuest subQuest)
    {
      switch (state)
      {
      }
    }

    private void OnSubQuestActivated(SubQuest subQuest)
    {
    }
  }
}