using System;
using Configs.Resources.QuestConfigs.SubQuestConfigs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

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