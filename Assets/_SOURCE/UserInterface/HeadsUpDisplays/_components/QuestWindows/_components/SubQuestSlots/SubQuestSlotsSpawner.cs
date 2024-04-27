using System;
using Quests;
using Quests.Subquests;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components.SubQuestSlots
{
  public class SubQuestSlotsSpawner : MonoBehaviour
  {
    [Inject] private SubQuestSlot.Factory _factory;
    [Inject] private Quest _quest;

    private void OnEnable()
    {
      CreateSubQuests();

      _quest.State.ValueChanged += QuestStateChanged;
    }

    private void QuestStateChanged(QuestState state)
    {
      switch (state)
      {
        case QuestState.Unknown:
          throw new ArgumentOutOfRangeException(nameof(QuestWindow.Quest.State));

        case QuestState.UnActivated:
          break;

        case QuestState.Activated:
          _quest.SubQuests[0].State.Value = QuestState.Activated;
          break;

        case QuestState.RewardReady:
          break;
      }
    }

    private void CreateSubQuests()
    {
      for (var i = 0; i < _quest.Config.SubQuests.Count; i++)
      {
        SubQuest subQuest = _quest.SubQuests[i];

        SubQuestSlot slot = _factory.Create(subQuest);

        slot.transform.SetParent(transform);
      }
    }
  }
}