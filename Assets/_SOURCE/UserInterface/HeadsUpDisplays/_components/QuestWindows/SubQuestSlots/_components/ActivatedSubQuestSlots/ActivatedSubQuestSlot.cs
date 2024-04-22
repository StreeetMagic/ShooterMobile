using System;
using Quests;
using UnityEngine;

public class ActivatedSubQuestSlot : MonoBehaviour
{
  public SubQuestSlot SubQuestSlot;
  public GameObject GrayButton;
  public GameObject GreenButton;

  private void Start()
  {
    SetupButtons(SubQuestSlot.SubQuest.State.Value);

    SubQuestSlot.SubQuest.State.ValueChanged += SetupButtons;
  }

  private void OnDestroy()
  {
    SubQuestSlot.SubQuest.State.ValueChanged -= SetupButtons;
  }

  private void SetupButtons(QuestState stateValue)
  {
    switch (stateValue)
    {
      case QuestState.Unknown:
        throw new ArgumentOutOfRangeException(nameof(SubQuestSlot.SubQuest.State));

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