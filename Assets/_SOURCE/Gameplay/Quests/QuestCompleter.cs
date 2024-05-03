using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.QuestConfigs.SubQuestConfigs.Scripts;
using Maps;
using Quests.Subquests;

namespace Quests
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

    public void OnEnemyKilled(EnemyId enemyId)
    {
      foreach (Quest quest in _storage.GetAllQuests())
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

    public void OnSubQuestStateChanged(QuestState state, SubQuest subQuest)
    {
      switch (state)
      {
        case QuestState.Activated:
          OnSubQuestActivated(subQuest);
          break;
      }
    }

    private void OnSubQuestActivated(SubQuest subQuest)
    {
      if (subQuest.Setup.Config.Type == SubQuestType.DefuseBomb)
      {
        _mapProvider.Map.BombSpawner.SpawnBombs(subQuest.Index);
      }
    }
  }
}