using Quests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components
{
  public class QuestTitle : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private Quest _quest;

    private void Start()
    {
      Text.text = "Quest: " + _quest.Config.Name;
    }
  }
}