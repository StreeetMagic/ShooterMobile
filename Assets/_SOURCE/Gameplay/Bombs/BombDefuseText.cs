using System;
using TMPro;
using UnityEngine;

public class BombDefuseText : MonoBehaviour
{
  public TextMeshProUGUI Text;
  public BombDefuser BombDefuser;

  private void Update()
  {
    SetText();
  }

  public void SetText()
  {
    int value = (int)(BombDefuser.DefuseProgress * 100);

    Text.text = $"{value}%";
  }
}