using Quests;
using Quests.Subquests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.Windows.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
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