using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.QuestWindows.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class RewardText : MonoBehaviour
  {
    public SubQuestSlot SubQuestSlot;
    public TextMeshProUGUI RewardTextComponent;

    void Start()
    {
      SetupText();
    }

    private void SetupText()
    {
      RewardTextComponent.text = "+ " + SubQuestSlot.SubQuest.Setup.Reward.Quantity + " " + SubQuestSlot.SubQuest.Setup.Reward.RewardId;
    }
  }
}