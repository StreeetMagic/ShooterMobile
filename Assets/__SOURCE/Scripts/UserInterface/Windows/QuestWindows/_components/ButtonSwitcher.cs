using System;
using Quests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.Windows.QuestWindows._components
{
  public class ButtonSwitcher : MonoBehaviour
  {
    public Button ActivateButton;
    public GameObject InProgressButton;
    public Button TakeRewardButton;

    [Inject] private Quest _quest;

    private void Start()
    {
      SetupButtons(_quest.State.Value);
      _quest.State.ValueChanged += SetupButtons;
    }

    private void OnDestroy()
    {
      _quest.State.ValueChanged -= SetupButtons;
    }

    private void SetupButtons(QuestState state)
    {
      switch (state)
      {
        case QuestState.Unknown:
          throw new ArgumentOutOfRangeException(nameof(_quest.State));

        case QuestState.UnActivated:
          ActivateButton.gameObject.SetActive(true);
          InProgressButton.SetActive(false);
          TakeRewardButton.gameObject.SetActive(false);
          break;

        case QuestState.Activated:
          ActivateButton.gameObject.SetActive(false);
          InProgressButton.SetActive(true);
          TakeRewardButton.gameObject.SetActive(false);
          break;

        case QuestState.RewardReady:
          ActivateButton.gameObject.SetActive(false);
          InProgressButton.SetActive(false);
          TakeRewardButton.gameObject.SetActive(true);
          break;

        case QuestState.RewardTaken:
          ActivateButton.gameObject.SetActive(false);
          InProgressButton.SetActive(false);
          TakeRewardButton.gameObject.SetActive(false);
          break;
      }
    }
  }
}