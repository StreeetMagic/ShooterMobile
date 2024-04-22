using System;
using DataRepositories.Quests;
using Quests;
using UnityEngine;

public class SubQuestSlot : MonoBehaviour
{
  public GameObject Unactivated;
  public GameObject Activated;
  public GameObject RewardTaken;

  public SubQuest SubQuest { get; set; }

  private void Start()
  {
    SetupStates(SubQuest.State.Value);

    SubQuest.State.ValueChanged += SetupStates;
  }

  private void OnDestroy()
  {
    SubQuest.State.ValueChanged -= SetupStates;
  }

  private void SetupStates(QuestState state)
  {
    switch (state)
    {
      case QuestState.Unknown:
        throw new ArgumentOutOfRangeException(nameof(SubQuest.State));

      case QuestState.UnActivated:
        Unactivated.SetActive(true);
        Activated.SetActive(false);
        RewardTaken.SetActive(false);
        break;

      case QuestState.Activated:
        Unactivated.SetActive(false);
        Activated.SetActive(true);
        RewardTaken.SetActive(false);
        break;
      
      case QuestState.RewardTaken:
        Unactivated.SetActive(false);
        Activated.SetActive(false);
        RewardTaken.SetActive(true);
        break;
    }
  }
}