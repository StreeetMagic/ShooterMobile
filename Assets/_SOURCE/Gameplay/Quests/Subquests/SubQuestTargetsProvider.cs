using System;
using System.Collections.Generic;
using System.Linq;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.QuestConfigs.Scripts;
using Configs.Resources.QuestConfigs.SubQuestConfigs.Scripts;
using Gameplay.Bombs;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Questers;
using Maps;
using Quests;
using Quests.Subquests;
using UnityEngine;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointers
{
  public class SubQuestTargetsProvider
  {
    private readonly EnemySpawnerFactory _enemySpawnerFactory;
    private readonly MapProvider _mapProvider;
    private readonly PlayerProvider _playerProvider;

    public SubQuestTargetsProvider(EnemySpawnerFactory enemySpawnerFactory,
      MapProvider mapProvider, PlayerProvider playerProvider)
    {
      _enemySpawnerFactory = enemySpawnerFactory;
      _mapProvider = mapProvider;
      _playerProvider = playerProvider;
    }

    public List<Transform> GetQuester(QuestId questId)
    {
      Quester quester =
        _mapProvider.Map
          .Questers
          .First(quester => quester.OpenQuestButtonEnabler.QuestId == questId);

      return new List<Transform> { quester.transform };
    }

    public List<Transform> GetTargetsOrNull(Quest quest)
    {
      List<SubQuest> subQuests = quest.SubQuests;

      foreach (SubQuest subQuest in subQuests)
      {
        switch (subQuest.State.Value)
        {
          case QuestState.Activated:
            return GetActivatedSubQuestTargetsOrNull(subQuest);

          case QuestState.RewardReady:
            return GetQuester(quest.Config.Id);
        }
      }

      throw new ArgumentOutOfRangeException();
    }

    private List<Transform> GetActivatedSubQuestTargetsOrNull(SubQuest subQuest)
    {
      switch (subQuest.Setup.Config.Type)
      {
        case SubQuestType.KillOrinaryPersons:
        case SubQuestType.DefuseBomb:
          return GetSubQuestTargetsOrNull(subQuest);

        case SubQuestType.Unknown:
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private List<Transform> GetSubQuestTargetsOrNull(SubQuest subQuest)
    {
      switch (subQuest.Setup.Config.Type)
      {
        case SubQuestType.KillOrinaryPersons:
          return GetKillOrinaryPersonsTargetsOrNull();

        case SubQuestType.DefuseBomb:
          return GetDefuseBombTargetsOrNull(subQuest);

        case SubQuestType.Unknown:
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private List<Transform> GetKillOrinaryPersonsTargetsOrNull()
    {
      EnemyId enemyId = EnemyId.WhiteShirt;

      List<EnemySpawner> spawners = _enemySpawnerFactory
        .Spawners
        .Where(spawner => spawner.EnemyId == enemyId)
        .ToList();

      List<Enemy> enemies = new List<Enemy>();

      foreach (EnemySpawner spawner in spawners)
      {
        enemies.AddRange(spawner.Enemies);
      }

      float minDistance = float.MaxValue;
      Enemy nearestEnemy = null;

      foreach (Enemy enemy in enemies)
      {
        float distance = Vector3.Distance(enemy.transform.position, _playerProvider.Player.transform.position);

        if (distance < minDistance)
        {
          minDistance = distance;
          nearestEnemy = enemy;
        }
      }

      if (nearestEnemy == null)
        return null;

      return new List<Transform> { nearestEnemy.transform };
    }

    private List<Transform> GetDefuseBombTargetsOrNull(SubQuest subQuest)
    {
      int index = subQuest.Index;
      BombSpawner spawner = _mapProvider.Map.BombSpawner;

      List<Bomb> bombs = spawner.Bombs[index];

      List<Bomb> activeBombs = bombs
          .Where(bomb => bomb.Defuser.IsDefused == false)
          .ToList();

      return activeBombs
        .Select(bomb => bomb.transform)
        .ToList();
    }
  }
}