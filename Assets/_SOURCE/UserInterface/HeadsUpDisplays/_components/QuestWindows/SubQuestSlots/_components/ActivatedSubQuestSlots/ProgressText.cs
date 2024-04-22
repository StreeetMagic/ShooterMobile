using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgressText : MonoBehaviour
{
  public SubQuestSlot SubQuestSlot;
  public TextMeshProUGUI Text;

  private void Start()
  {
    SetupText(SubQuestSlot.SubQuest.CompletedQuantity.Value);
    SubQuestSlot.SubQuest.CompletedQuantity.ValueChanged += SetupText;
  }

  private void SetupText(int _)
  {
    int current = SubQuestSlot.SubQuest.CompletedQuantity.Value;
    int max = SubQuestSlot.SubQuest.Setup.Quantity;

    Text.text = $"{current}/{max}";

    if (current >= max)
    {
      Text.text = "Done!";
    }
  }
}