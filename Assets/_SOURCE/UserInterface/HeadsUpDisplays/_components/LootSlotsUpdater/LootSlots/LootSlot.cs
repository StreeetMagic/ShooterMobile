using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootSlot : MonoBehaviour
{
  public Image Image;
  public TextMeshProUGUI Text;

  public void Init(Sprite icon, int lootValue)
  {
    Image.sprite = icon;
    Text.text = lootValue.ToString();
  }
}