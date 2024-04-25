using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components
{
  public class QuestIcon : MonoBehaviour
  {
    public Image Image;
    public QuestWindow QuestWindow;

    private void Start()
    {
      Image.sprite = QuestWindow.Quest.Config.Icon;
    }
  }
}