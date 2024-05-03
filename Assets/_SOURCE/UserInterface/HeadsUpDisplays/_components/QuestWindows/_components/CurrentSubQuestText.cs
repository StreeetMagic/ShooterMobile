using System.Collections.Generic;
using Quests;
using Quests.Subquests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class CurrentSubQuestText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private Quest _quest;

    private void Update()
    {
      List<SubQuest> subQuests = _quest.SubQuests;

      foreach (SubQuest subQuest in subQuests)
      {
        if (subQuest.State.Value is QuestState.Activated or QuestState.RewardReady)
        {
          SetText(subQuest.Setup.Config.Description + "(" + subQuest.Setup.Quantity + ")");
          return;
        }

        SetText("");
      }

      if (_quest.State.Value == QuestState.RewardTaken)
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