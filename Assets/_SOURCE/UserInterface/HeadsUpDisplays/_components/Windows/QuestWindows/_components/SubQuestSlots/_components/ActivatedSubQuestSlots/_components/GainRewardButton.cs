using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows.SubQuestSlots.ActivatedSubQuestSlots
{
  public class GainRewardButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private SubQuest _subQuest;

    private void OnEnable()
    {
      SetupButton();
    }

    private void SetupButton()
    {
      Button.onClick.AddListener(() => _subQuest.State.Value = QuestState.RewardTaken);
    }
  }
}