using System;
using Quests;
using UnityEngine;
using UnityEngine.UI;
using UserInterface.HeadsUpDisplays.QuestWindows;

public class ActivateQuestButton : MonoBehaviour
{
  public Button Button;
  public QuestWindow QuestWindow;

  private Quest Quest => QuestWindow.Quest;

  private void Start()
  {
    Button.onClick.AddListener(Activate);
  }

  private void Activate()
  {
    Quest.State.Value = QuestState.Activated;
  }
}