using Infrastructure.ArtConfigServices;
using Quests.Subquests;
using Rewards;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.Windows.QuestWindows._components.SubQuestSlots._components.ActivatedSubQuestSlots._components
{
  public class RewardIcon : MonoBehaviour
  {
    public Image Image;

    [Inject] private SubQuest _subQuest;
    [Inject] private ArtConfigProvider _artConfigProvider;

    private void OnEnable()
    {
      RewardContentSetup contentSetup = _artConfigProvider.GetRewardContentSetup(_subQuest.Setup.Reward.RewardId);

      Image.sprite = contentSetup.Icon;
    }
  }
}