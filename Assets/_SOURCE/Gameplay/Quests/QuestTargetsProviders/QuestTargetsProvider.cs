using System;
using System.Collections.Generic;
using System.Linq;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.QuestConfigs.Scripts;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Questers;
using Maps;
using Quests;
using UnityEngine;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointers
{
  public class QuestTargetsProvider
  {
    private readonly EnemySpawnerFactory _enemySpawnerFactory;
    private readonly QuestStorage _storage;
    private readonly MapProvider _mapProvider;

    public QuestTargetsProvider(EnemySpawnerFactory enemySpawnerFactory, QuestStorage storage, MapProvider mapProvider)
    {
      _enemySpawnerFactory = enemySpawnerFactory;
      _storage = storage;
      _mapProvider = mapProvider;
    }

    public List<Transform> GetTargetsOrNull(QuestId questId)
    {
      switch (questId)
      {
        case QuestId.Unknown:
          return null; 

        case QuestId.Quest1:
          return GetQuest1TargetsOrNull();

        case QuestId.Quest2:
          return GetQuest2TargetsOrNull();

        default:
           return null;
      }
    }

    private List<Transform> GetQuest1TargetsOrNull()
    {
      Quest quest = _storage.GetQuest(QuestId.Quest1);

      if (quest.State.Value == QuestState.RewardReady || quest.State.Value == QuestState.UnActivated)
      {
        Quester quester = _mapProvider.Map.Questers.First(q => q.OpenQuestButtonEnabler.QuestId == QuestId.Quest1);

        return new List<Transform> { quester.transform };
      }
      else if (quest.State.Value == QuestState.Activated)
      {
        List<EnemySpawner> spawners = new List<EnemySpawner>();

        foreach (EnemySpawner spawner in _enemySpawnerFactory.Spawners)
        {
          if (spawner.EnemyId == EnemyId.WhiteShirt)
            spawners.Add(spawner);
        }

        List<Transform> targets = new List<Transform>();

        foreach (EnemySpawner spawner in spawners)
          targets.Add(spawner.transform);

        return targets;
      }

      return null;
    }

    private List<Transform> GetQuest2TargetsOrNull()
    {
       return null;
    }
  }
}