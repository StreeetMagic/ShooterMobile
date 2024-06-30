using Infrastructure.ArtConfigServices;
using Quests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.Windows.QuestWindows._components
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