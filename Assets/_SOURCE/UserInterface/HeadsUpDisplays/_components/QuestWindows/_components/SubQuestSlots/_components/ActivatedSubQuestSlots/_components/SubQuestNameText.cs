using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class SubQuestNameText : MonoBehaviour
  {
    public TextMeshProUGUI Text;
    
    [Inject] private SubQuestSlot _subQuestSlot;

    private void Start()
    {
      SetupText();
    }

    private void SetupText()
    {
      Text.text = _subQuestSlot.SubQuest.Setup.Config.Name;
    }
  }
}