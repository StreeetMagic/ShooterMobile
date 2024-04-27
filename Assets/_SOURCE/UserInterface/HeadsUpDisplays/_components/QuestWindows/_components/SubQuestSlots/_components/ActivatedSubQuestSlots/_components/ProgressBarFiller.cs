using System;
using Configs.Resources.QuestConfigs.Scripts;
using Quests.Subquests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class ProgressBarFiller : MonoBehaviour
  {
    public Slider Slider;

    [Inject] private SubQuest _subQuest;
    [Inject] private SubQuestSetup _setup;

    private void Update()
    {
      Slider.value = (float)_subQuest.CompletedQuantity.Value / _setup.Quantity;
    }
  }
}