using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows.SubQuestSlots.ActivatedSubQuestSlots
{
  public class SubQuestIcon : MonoBehaviour
  {
    public Image Image;
    
    [Inject] private SubQuestSlot _subQuestSlot;

    private void OnEnable()
    {
      SetupIcon();
    }

    private void SetupIcon()
    {
      Image.sprite = _subQuestSlot.SubQuest.ContentSetup.Icon;
    }
  }
}