using Gameplay.Quests.Subquests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows.SubQuestSlots.ActivatedSubQuestSlots
{
  public class ProgressText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private SubQuest _subQuest;

    private void OnEnable()
    {
      SetupText(_subQuest.CompletedQuantity.Value);
      _subQuest.CompletedQuantity.ValueChanged += SetupText;
    }

    private void SetupText(int _)
    {
      int current = _subQuest.CompletedQuantity.Value;
      int max = _subQuest.Setup.Quantity;

      Text.text = $"{current}/{max}";

      if (current >= max)
      {
        Text.text = "Done!";
      }
    }
  }
}