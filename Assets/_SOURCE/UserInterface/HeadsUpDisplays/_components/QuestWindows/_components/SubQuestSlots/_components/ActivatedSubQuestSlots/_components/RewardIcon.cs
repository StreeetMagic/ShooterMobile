using Configs.Resources.RewardConfigs;
using Infrastructure.StaticDataServices;
using Quests.Subquests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class RewardIcon : MonoBehaviour
  {
    public Image Image;

    [Inject] private SubQuest _subQuest;
    [Inject] private IStaticDataService _staticDataService;

    private void OnEnable()
    {
      RewardConfig rewardConfig = _staticDataService.GetRewardConfigs()[_subQuest.Setup.Reward.RewardId];

      Image.sprite = rewardConfig.Icon;
    }
  }
}