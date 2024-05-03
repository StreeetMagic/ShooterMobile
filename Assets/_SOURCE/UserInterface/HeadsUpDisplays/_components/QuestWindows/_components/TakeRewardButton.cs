using Quests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class TakeRewardButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private Quest _quest;

    private void Start()
    {
      Button.onClick.AddListener(() => _quest.GainReward());
    }
  }
}