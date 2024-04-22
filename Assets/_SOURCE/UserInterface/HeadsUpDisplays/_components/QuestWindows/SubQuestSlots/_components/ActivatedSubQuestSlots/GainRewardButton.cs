
using Quests;
using UnityEngine;
using UnityEngine.UI;

public class GainRewardButton : MonoBehaviour
{
  public SubQuestSlot SubQuestSlot;
  public Button Button;

  private void Start()
  {
    SetupButton();
  }

  private void SetupButton()
  {
    Button.onClick.AddListener(() => SubQuestSlot.SubQuest.State.Value = QuestState.RewardTaken);
  }
}