using Configs.Resources.QuestConfigs.Scripts;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class QuestRewardText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private QuestConfig _config;

    private void Start()
    {
      Text.text = "+ " + _config.Reward.Quantity + " " + _config.Reward.RewardId;
    }
  }
}