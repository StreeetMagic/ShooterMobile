using Gameplay.Quests.Subquests;
using Gameplay.Rewards;
using Infrastructure.ConfigServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class RewardIcon : MonoBehaviour
  {
    public Image Image;

    [Inject] private SubQuest _subQuest;
    [Inject] private ConfigService _configService;

    private void OnEnable()
    {
      RewardConfig rewardConfig = _configService.RewardConfigs[_subQuest.Setup.Reward.RewardId];

      Image.sprite = rewardConfig.Icon;
    }
  }
}