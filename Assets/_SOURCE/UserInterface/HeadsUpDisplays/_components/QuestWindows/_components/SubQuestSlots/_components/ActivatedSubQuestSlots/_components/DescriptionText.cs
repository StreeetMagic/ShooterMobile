using Quests.Subquests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class DescriptionText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private SubQuest _subQuest;

    private void Update()
    {
      int setupQuantity = _subQuest.Setup.Quantity;
      string description = _subQuest.Setup.Config.Description;

      Text.text = description + "(" + setupQuantity + ")";
    }
  }
}