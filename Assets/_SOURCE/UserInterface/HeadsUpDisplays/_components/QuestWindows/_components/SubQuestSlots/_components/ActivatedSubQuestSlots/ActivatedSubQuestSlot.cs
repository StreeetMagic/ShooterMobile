using System;
using Quests;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots
{
  public class ActivatedSubQuestSlot : MonoBehaviour
  {
    public GameObject GrayButton;
    public GameObject GreenButton;

    [Inject] private SubQuestSlot _subQuestSlot;

    private void OnEnable()
    {
      SetupButtons(_subQuestSlot.SubQuest.State.Value);

      _subQuestSlot.SubQuest.State.ValueChanged += SetupButtons;
    }

    private void OnDisable()
    {
      _subQuestSlot.SubQuest.State.ValueChanged -= SetupButtons;
    }

    private void SetupButtons(QuestState stateValue)
    {
      switch (stateValue)
      {
        case QuestState.Unknown:
          throw new ArgumentOutOfRangeException(nameof(_subQuestSlot.SubQuest.State));

        case QuestState.UnActivated:
          GrayButton.SetActive(false);
          GreenButton.SetActive(false);
          break;

        case QuestState.Activated:
          GrayButton.SetActive(true);
          GreenButton.SetActive(false);
          break;

        case QuestState.RewardReady:
          GrayButton.SetActive(false);
          GreenButton.SetActive(true);
          break;

        case QuestState.RewardTaken:
          GrayButton.SetActive(false);
          GreenButton.SetActive(false);
          break;
      }
    }
  }
}