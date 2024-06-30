using Quests;
using Quests.Subquests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.Windows.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
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