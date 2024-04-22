using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using UnityEngine;
using UnityEngine.UI;
using UserInterface.HeadsUpDisplays.QuestWindows;

public class ButtonSwitcher : MonoBehaviour
{
  public Button ActivateButton;
  public GameObject InProgressButton;
  public Button TakeRewardButton;

  public QuestWindow QuestWindow;

  private Quest Quest => QuestWindow.Quest;

  private void Start()
  {
    SetupButtons(Quest.State.Value);
    Quest.State.ValueChanged += SetupButtons;
  }

  private void OnDestroy()
  {
    Quest.State.ValueChanged -= SetupButtons;
  }

  private void SetupButtons(QuestState state)
  {
    switch (state)
    {
      case QuestState.Unknown:
        throw new ArgumentOutOfRangeException(nameof(Quest.State));

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