using Gameplay.Quests;
using Infrastructure.ConfigProviders;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows
{
  public class QuestRewardText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private QuestId _id;
    [Inject] private ConfigProvider _configProvider;

    private void Start()
    {
      Text.text = "+ " + _configProvider.GetQuestConfig(_id).Reward.Quantity + " " + _configProvider.GetQuestConfig(_id).Reward.RewardId;
    }
  }
}