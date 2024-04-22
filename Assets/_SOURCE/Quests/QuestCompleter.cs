using System.Collections.Generic;
using Configs.Resources.QuestConfigs.SubQuestConfigs;
using DataRepositories.Quests;
using Gameplay.Characters.Enemies;

namespace Quests
{
  public class QuestCompleter
  {
    private readonly QuestStorage _storage;

    public QuestCompleter(QuestStorage storage)
    {
      _storage = storage;
    }

    public void OnEnemyKilled(EnemyId enemyId)
    {
      foreach (var quest in _storage.GetAllQuests())
      {
        foreach (SubQuest subQuest in quest.SubQuests)
        {
          if (subQuest.State.Value != QuestState.Activated)
            continue;
          
          if (subQuest.Setup.Config.Type != SubQuestType.KillOrinaryPersons)
            continue;

          if (enemyId == EnemyId.WhiteShirt)
            subQuest.CompletedQuantity.Value++;
        }
      }
    }
  }
}