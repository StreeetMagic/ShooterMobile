using System;
using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using UnityEngine;
using Zenject;
using Zenject.Source.Factories;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows.SubQuestSlots
{
  public class SubQuestSlot : MonoBehaviour
  {
    public GameObject Unactivated;
    public GameObject Activated;
    public GameObject RewardReady;
    public GameObject RewardTaken;

    [Inject] public SubQuest SubQuest { get; private set; }

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
      DisableAll();

      switch (state)
      {
        case QuestState.Unknown:
          throw new ArgumentOutOfRangeException(nameof(SubQuest.State));

        case QuestState.UnActivated:
          Unactivated.SetActive(true);
          break;

        case QuestState.Activated:
          Activated.SetActive(true);
          break;

        case QuestState.RewardReady:
          RewardReady.SetActive(true);
          break;

        case QuestState.RewardTaken:
          RewardTaken.SetActive(true);
          break;
      }
    }

    private void DisableAll()
    {
      Unactivated.SetActive(false);
      Activated.SetActive(false);
      RewardReady.SetActive(false);
      RewardTaken.SetActive(false);
    }

    public class Factory : PlaceholderFactory<SubQuest, SubQuestSlot>
    {
    }
  }
}