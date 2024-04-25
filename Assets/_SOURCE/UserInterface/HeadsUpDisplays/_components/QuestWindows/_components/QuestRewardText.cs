using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components
{
  public class QuestRewardText : MonoBehaviour
  {
    public QuestWindow QuestWindow;
    public TextMeshProUGUI Text;

    private void Start()
    {
      Text.text = "+ " + QuestWindow.Quest.Config.Reward.Quantity + " " + QuestWindow.Quest.Config.Reward.RewardId;
    }
  }
}