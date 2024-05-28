using Gameplay.Quests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows._components
{
  public class QuestIcon : MonoBehaviour
  {
    public Image Image;

    [Inject] private QuestConfig _config;

    private void OnEnable()
    {
      Image.sprite = _config.Icon;
    }
  }
}