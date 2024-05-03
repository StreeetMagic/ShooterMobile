using Configs.Resources.QuestConfigs.Scripts;
using Infrastructure.UserIntefaces;
using Loggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.OpenQuestButtons
{
  public class OpenQuestButton : MonoBehaviour
  {
    public Button Button;
    public QuestId QuestId { get; set; } = QuestId.Unknown;

    private WindowService _windowService;

    [Inject]
    private void Construct(WindowService windowService, DebugLogger logger)
    {
      _windowService = windowService;
      Button.onClick.AddListener(OpenQuest);
    }

    private void OpenQuest()
    {
      if (QuestId == QuestId.Unknown)
        throw new System.Exception("Unknown quest id");

      _windowService.Create(WindowId.Quest, QuestId);
    }
  }
}