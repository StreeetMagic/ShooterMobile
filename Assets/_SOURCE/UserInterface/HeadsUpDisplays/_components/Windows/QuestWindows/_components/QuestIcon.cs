using Quests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class QuestIcon : MonoBehaviour
  {
    public Image Image;
    
    [Inject] private Quest _quest;

    private void OnEnable()
    {
      Image.sprite = _quest.Config.Icon;
    }
  }
}