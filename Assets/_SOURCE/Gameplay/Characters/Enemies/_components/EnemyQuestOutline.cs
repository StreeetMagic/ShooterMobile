using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Resources.QuestConfigs.SubQuestConfigs;
using DataRepositories.Quests;
using Gameplay.Characters.Enemies;
using Quests;
using UnityEngine;
using Zenject;

public class EnemyQuestOutline : MonoBehaviour
{
  public GameObject Outline;

  private QuestStorage _storage;
  private Enemy _enemy;

  [Inject]
  private void Construct(QuestStorage storage, Enemy enemy)
  {
    _storage = storage;
    _enemy = enemy;
  }

  private void OnEnable()
  {
    Outline.SetActive(false);
  }

  private void Update()
  {
    Outline.SetActive(HasActiveSubQuest());
  }

  private bool HasActiveSubQuest()
  {
    foreach (Quest quest in _storage.GetAllQuests())
    {
      foreach (SubQuest subQuest in quest.SubQuests)
      {
        if (subQuest.State.Value == QuestState.Activated)
        {
          if (subQuest.Setup.Config.Type == SubQuestType.KillOrinaryPersons)
          {
            return true;
          }
        }
      }
    }

    return false;
  }
}