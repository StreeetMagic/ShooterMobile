using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components
{
  public class TakeRewardButton : MonoBehaviour
  {
    public QuestWindow QuestWindow;
    public Button Button;

    private void Start()
    {
      Button.onClick.AddListener(() => QuestWindow.Quest.GainReward());
    }
  }
}