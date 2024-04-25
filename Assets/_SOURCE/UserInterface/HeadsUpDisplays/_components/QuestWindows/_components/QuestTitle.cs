using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components
{
    public class QuestTitle : MonoBehaviour
    {
        public TextMeshProUGUI Text;
        public QuestWindow QuestWindow;

        private void Start()
        {
            Text.text = "Quest: " + QuestWindow.Quest.Config.Name;
        }
    }
}
