using Infrastructure.UserIntefaces;
using Loggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenQuestButton : MonoBehaviour
{
  public Button Button;
  public QuestId QuestId;

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
    _windowService.Create(WindowId.Quest, QuestId);
    _logger.Log("Open quest: " + QuestId);
  }
}