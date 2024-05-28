using System;
using System.Collections.Generic;
using Gameplay.Quests.Subquests;
using UnityEngine;

namespace Gameplay.Quests
{
  public class QuestTargetsProvider
  {
    private readonly QuestStorage _storage;
    private readonly SubQuestTargetsProvider _subQuestTargetsProvider;

    public QuestTargetsProvider(QuestStorage storage, SubQuestTargetsProvider subQuestTargetsProvider)
    {
      _storage = storage;
      _subQuestTargetsProvider = subQuestTargetsProvider;
    }

    public List<Transform> GetTargetsOrNull(QuestId questId)
    {
      switch (questId)
      {
        case QuestId.Quest1:
        case QuestId.Quest2:
          return GetQuestTargetsOrNull(questId);

        case QuestId.Unknown:
        default:
          throw new ArgumentOutOfRangeException(nameof(questId), questId, null);
      }
    }

    private List<Transform> GetQuestTargetsOrNull(QuestId questId)
    {
      Quest quest = _storage.GetQuest(questId);

      switch (quest.State.Value)
      {
        case QuestState.UnActivated:
        case QuestState.RewardReady:
          return _subQuestTargetsProvider.GetQuester(questId);

        case QuestState.Activated:
          return _subQuestTargetsProvider.GetTargetsOrNull(quest);

        case QuestState.RewardTaken:
          return null;

        case QuestState.Unknown:
        default:
          throw new ArgumentOutOfRangeException(nameof(questId), questId, null);
      }
    }
  }
}