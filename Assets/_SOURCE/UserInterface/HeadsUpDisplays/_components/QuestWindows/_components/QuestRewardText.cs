using Quests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class QuestRewardText : MonoBehaviour
  {
    public TextMeshProUGUI Text;
    
    [Inject] private Quest _quest;

    private void Start()
    {
      Text.text = "+ " + _quest.Config.Reward.Quantity + " " + _quest.Config.Reward.RewardId;
    }
  }
}