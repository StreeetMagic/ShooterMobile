using Gameplay.Quests.Subquests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class RewardText : MonoBehaviour
  {
    public TextMeshProUGUI RewardTextComponent;

    [Inject] private SubQuest _subQuest;

    private void OnEnable()
    {
      SetupText();
    }

    private void SetupText()
    {
      RewardTextComponent.text = _subQuest.Setup.Reward.Quantity.ToString();
    }
  }
}