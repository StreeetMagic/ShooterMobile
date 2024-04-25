using Quests;
using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components
{
  public class CurrentSubQuestText : MonoBehaviour
  {
    public QuestWindow QuestWindow;
    public TextMeshProUGUI Text;

    private void Update()
    {
      var subQuests = QuestWindow.Quest.SubQuests;

      foreach (var subQuest in subQuests)
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