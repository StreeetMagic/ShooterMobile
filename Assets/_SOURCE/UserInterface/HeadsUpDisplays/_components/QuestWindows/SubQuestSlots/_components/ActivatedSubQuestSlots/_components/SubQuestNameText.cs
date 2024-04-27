using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.QuestWindows.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class SubQuestNameText : MonoBehaviour
  {
    public SubQuestSlot SubQuestSlot;
    public TextMeshProUGUI Text;

    private void Start()
    {
      SetupText();
    }

    private void SetupText()
    {
      Text.text = SubQuestSlot.SubQuest.Setup.Config.Name;
    }
  }
}