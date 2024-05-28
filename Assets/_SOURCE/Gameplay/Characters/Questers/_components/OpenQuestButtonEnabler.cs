using Cameras;
using Gameplay.Characters.Players;
using Gameplay.Quests;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.Buttons.OpenQuestButtons;
using Zenject;

namespace Gameplay.Characters.Questers._components
{
  public class OpenQuestButtonEnabler : MonoBehaviour
  {
    public const float Distance = 4;

    public float YOffset = 200;
    public QuestId QuestId;
    public bool IsActive;

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private HeadsUpDisplayProvider _headsUpDisplayProvider;
    [Inject] private CameraProvider _cameraProvider;

    private void OnEnable()
    {
      if (QuestId == QuestId.Unknown)
        throw new System.Exception("Unknown quest id");
    }

    private void Update()
    {
      if (_playerProvider.Player == null)
        return;

      float distance = Vector3.Distance(transform.position, _playerProvider.Player.transform.position);

      if (distance < Distance)
      {
        _headsUpDisplayProvider.OpenQuestButton.QuestId = QuestId;
        SetButtonPosition(_headsUpDisplayProvider.OpenQuestButton);
        IsActive = true;
      }
      else
      {
        IsActive = false;
      }
    }

    private void SetButtonPosition(OpenQuestButton openQuestButton)
    {
      Vector2 screenPoint = _cameraProvider.MainCamera.WorldToScreenPoint(transform.position);

      RectTransformUtility.ScreenPointToLocalPointInRectangle(_headsUpDisplayProvider.CanvasTransform, screenPoint, null, out Vector2 localPoint);

      openQuestButton.RectTransform.anchoredPosition = localPoint + Vector2.up * YOffset;
    }
  }
}