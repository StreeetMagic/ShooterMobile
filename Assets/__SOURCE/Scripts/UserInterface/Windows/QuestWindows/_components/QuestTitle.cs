using Infrastructure.ArtConfigServices;
using Quests;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.Windows.QuestWindows._components
{
  public class QuestTitle : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private QuestId _id;
    [Inject] private ArtConfigProvider _artConfig;

    private void OnEnable()
    {
      Text.text = "Quest: " + _artConfig.GetQuestContentSetup(_id).Name;
    }
  }
}