using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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