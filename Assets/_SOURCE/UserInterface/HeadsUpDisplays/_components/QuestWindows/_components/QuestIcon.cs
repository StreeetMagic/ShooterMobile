using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class QuestIcon : MonoBehaviour
  {
    public Image Image;
    public QuestWindow QuestWindow;

    private void OnEnable()
    {
      Image.sprite = QuestWindow.Quest.Config.Icon;
    }
  }
}