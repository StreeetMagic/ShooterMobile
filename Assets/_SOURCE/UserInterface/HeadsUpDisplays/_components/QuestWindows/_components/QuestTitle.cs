using Quests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components
{
  public class QuestTitle : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    private Quest _quest;
    
    [Inject]
    public void Construct(Quest quest)
    {
      _quest = quest;
    }

    private void OnEnable()
    {
      Text.text = "Quest: " + _quest.Config.Name;
    }
  }
}