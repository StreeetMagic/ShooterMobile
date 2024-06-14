using Gameplay.Quests.Subquests;
using Gameplay.Rewards;
using Infrastructure.ArtConfigServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class RewardIcon : MonoBehaviour
  {
    public Image Image;

    [Inject] private SubQuest _subQuest;
    [Inject] private ArtConfigService _artConfigService;

    private void OnEnable()
    {
      RewardContentSetup contentSetup = _artConfigService.GetRewardContentSetup(_subQuest.Setup.Reward.RewardId);

      Image.sprite = contentSetup.Icon;
    }
  }
}