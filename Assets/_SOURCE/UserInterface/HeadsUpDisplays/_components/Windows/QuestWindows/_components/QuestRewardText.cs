using Gameplay.Quests;
using Infrastructure.ConfigServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows
{
  public class QuestRewardText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private QuestId _id;
    [Inject] private ConfigService _configService;

    private void Start()
    {
      Text.text = "+ " + _configService.GetQuestConfig(_id).Reward.Quantity + " " + _configService.GetQuestConfig(_id).Reward.RewardId;
    }
  }
}