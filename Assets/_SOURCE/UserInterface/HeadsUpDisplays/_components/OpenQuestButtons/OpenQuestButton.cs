using Configs.Resources.QuestConfigs.Scripts;
using Infrastructure.UserIntefaces;
using Loggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.Characters.Questers
{
  public class OpenQuestButton : MonoBehaviour
  {
    public Button Button;
    public QuestId QuestId { get; set; } = QuestId.Unknown;

    private WindowService _windowService;
    private DebugLogger _logger;

    [Inject]
    private void Construct(WindowService windowService, DebugLogger logger)
    {
      _windowService = windowService;
      _logger = logger;
      Button.onClick.AddListener(OpenQuest);
    }

    private void OpenQuest()
    {
      if (QuestId == QuestId.Unknown)
        throw new System.Exception("Unknown quest id");

      _windowService.Create(WindowId.Quest, QuestId);
      _logger.Log("Open quest: " + QuestId);
    }
  }
}