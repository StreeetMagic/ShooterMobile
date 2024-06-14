using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Bombs;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Players;
using Gameplay.Characters.Questers;
using Gameplay.Spawners;
using Gameplay.Spawners.SpawnerFactories;
using Maps;
using UnityEngine;

namespace Gameplay.Quests.Subquests
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
      switch (subQuest.ContentSetup.Id)
      {
        case SubQuestId.KillTerKnife:
        case SubQuestId.DefuseBomb:
          return GetSubQuestTargetsOrNull(subQuest);

        case SubQuestId.Unknown:
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private List<Transform> GetSubQuestTargetsOrNull(SubQuest subQuest)
    {
      switch (subQuest.ContentSetup.Id)
      {
        case SubQuestId.Unknown:
          throw new ArgumentOutOfRangeException();
        
        case SubQuestId.KillTerKnife:
          return GetKillOrinaryPersonsTargetsOrNull();

        case SubQuestId.DefuseBomb:
          return GetDefuseBombTargetsOrNull();

        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private List<Transform> GetKillOrinaryPersonsTargetsOrNull()
    {
      EnemyTypeId enemyId = EnemyTypeId.TerKnife;

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
        float distance = Vector3.Distance(enemy.transform.position, _playerProvider.Instance.transform.position);

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

    private List<Transform> GetDefuseBombTargetsOrNull()
    {
      BombSpawner spawner = _mapProvider.Map.BombSpawner;

      List<Bomb> bombs = spawner.Bombs;

      List<Bomb> activeBombs = bombs
        .Where(bomb => bomb.Defuser.IsDefused == false)
        .ToList();

      return activeBombs
        .Select(bomb => bomb.transform)
        .ToList();
    }
  }
}