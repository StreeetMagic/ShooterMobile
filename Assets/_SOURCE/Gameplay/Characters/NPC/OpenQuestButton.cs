using Infrastructure.UserIntefaces;
using Loggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenQuestButton : MonoBehaviour
{
  public Button Button;
  public QuestId QuestId;

  private WindowFactory _windowFactory;
  private DebugLogger _logger;

  [Inject]
  private void Construct(WindowFactory windowFactory, DebugLogger logger)
  {
    _windowFactory = windowFactory;
    _logger = logger;
    Button.onClick.AddListener(OpenQuest);
  }

  private void OpenQuest()
  {
    _windowFactory.Create(WindowId.Quest, QuestId);
    _logger.Log("Open quest: " + QuestId);
  }
}