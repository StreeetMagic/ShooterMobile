using Gameplay.Quests;
using Infrastructure.ArtConfigServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows
{
  public class QuestTitle : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private QuestId _id;
    [Inject] private ArtConfigService _artConfig;

    private void OnEnable()
    {
      Text.text = "Quest: " + _artConfig.GetQuestContentSetup(_id).Name;
    }
  }
}