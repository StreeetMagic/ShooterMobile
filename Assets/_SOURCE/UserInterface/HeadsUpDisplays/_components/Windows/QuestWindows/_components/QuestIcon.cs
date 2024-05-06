using Configs.Resources.QuestConfigs.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows
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