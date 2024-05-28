using Gameplay.Quests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows._components
{
  public class QuestTitle : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private QuestConfig _config;

    private void OnEnable()
    {
      Text.text = "Quest: " + _config.Name;
    }
  }
}