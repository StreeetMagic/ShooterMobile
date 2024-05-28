using Gameplay.Quests;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows._components.SubQuestSlots._components
{
  public class CompleteImage : MonoBehaviour
  {
    public SubQuestSlot SubQuestSlot;
    public Image Image;

    private void Update()
    {
      Image.enabled = SubQuestSlot.SubQuest.State.Value == QuestState.RewardTaken;
    }
  }
}