using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.HeadsUpDisplays.QuestWindows.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class SubQuestIcon : MonoBehaviour
  {
    public SubQuestSlot SubQuestSlot;
    public Image Image;

    private void Start()
    {
      SetupIcon();
    }

    private void SetupIcon()
    {
      Image.sprite = SubQuestSlot.SubQuest.Setup.Config.Icon;
    }
  }
}