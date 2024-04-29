using System.Collections.Generic;
using Quests;
using Quests.Subquests;
using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class CurrentSubQuestText : MonoBehaviour
  {
    public QuestWindow QuestWindow;
    public TextMeshProUGUI Text;

    private void Update()
    {
      List<SubQuest> subQuests = QuestWindow.Quest.SubQuests;

      foreach (SubQuest subQuest in subQuests)
      {
        if (subQuest.State.Value is QuestState.Activated or QuestState.RewardReady)
        {
          SetText(subQuest.Setup.Config.Description + "(" + subQuest.Setup.Quantity + ")");
          return;
        }

        SetText("");
      }

      if (QuestWindow.Quest.State.Value == QuestState.RewardTaken)
      {
        SetText("Completed");
      }
    }

    private void SetText(string text)
    {
      Text.text = text;
    }
  }
}