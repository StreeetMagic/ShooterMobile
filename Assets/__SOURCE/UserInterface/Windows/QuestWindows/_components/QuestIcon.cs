using Gameplay.Quests;
using Infrastructure.ArtConfigServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows
{
  public class QuestIcon : MonoBehaviour
  {
    public Image Image;

    [Inject] private QuestId _id;
    [Inject] private ArtConfigProvider _artConfig;

    private void OnEnable()
    {
      Image.sprite = _artConfig.GetQuestContentSetup(_id).Icon;
    }
  }
}