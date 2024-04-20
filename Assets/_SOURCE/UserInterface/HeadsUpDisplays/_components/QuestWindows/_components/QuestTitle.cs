using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UserInterface.HeadsUpDisplays.QuestWindows;

public class QuestTitle : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public QuestWindow QuestWindow;

    private void Start()
    {
        Text.text = "Quest: " + QuestWindow.Quest.Config.Name;
    }
}
