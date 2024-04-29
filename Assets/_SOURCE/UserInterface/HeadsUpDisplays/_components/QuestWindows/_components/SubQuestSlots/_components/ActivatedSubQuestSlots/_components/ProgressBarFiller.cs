using Configs.Resources.QuestConfigs.Scripts;
using Quests.Subquests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows.SubQuestSlots.ActivatedSubQuestSlots
{
  public class ProgressBarFiller : MonoBehaviour
  {
    public Slider Slider;

    [Inject] private SubQuest _subQuest;
    [Inject] private SubQuestSetup _setup;

    private void Update()
    {
      var completedQuantityValue = (float)_subQuest.CompletedQuantity.Value;
      int setupQuantity = _setup.Quantity;
      float progress = completedQuantityValue / setupQuantity;

      Slider.value = Slider.value < progress
        ? Mathf.MoveTowards(Slider.value, progress, Time.deltaTime)
        : progress;
    }
  }
}