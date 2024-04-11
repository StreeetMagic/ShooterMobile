using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UserInterface.HeadsUpDisplays.QuestWindows;

public class QuestIcon : MonoBehaviour
{
  public Image Image;
  public QuestWindow QuestWindow;

  private void Start()
  {
    Image.sprite = QuestWindow.QuestConfig.Icon;
  }
}