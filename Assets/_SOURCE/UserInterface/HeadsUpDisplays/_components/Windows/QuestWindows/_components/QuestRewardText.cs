using Gameplay.Quests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows._components
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