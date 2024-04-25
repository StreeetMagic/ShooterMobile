using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.QuestWindows.SubQuestSlots._components.ActivatedSubQuestSlots
{
  public class DescriptionText : MonoBehaviour
  {
    public SubQuestSlot SubQuestSlot;
    public TextMeshProUGUI Text;

    private void Update()
    {
      int setupQuantity = SubQuestSlot.SubQuest.Setup.Quantity;
      string description = SubQuestSlot.SubQuest.Setup.Config.Description;

      Text.text = description + "(" + setupQuantity + ")";
    }
  }
}