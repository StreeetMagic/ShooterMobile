using Cameras;
using Gameplay.Characters.Players.Factories;
using Infrastructure.UserIntefaces;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.OpenQuestButtons;
using Zenject;

public class OpenShopButtonEnabler : MonoBehaviour
{
  public const float Distance = 4;

  public float YOffset = 200;
  public WindowId WindowId;
  public bool IsActive;

  [Inject] private PlayerProvider _playerProvider;
  [Inject] private HeadsUpDisplayProvider _headsUpDisplayProvider;
  [Inject] private CameraProvider _cameraProvider;

  private void OnEnable()
  {
    switch (WindowId)
    {
      case WindowId.HenShop:
      case WindowId.UpgradeShop:
        return;

      default:
        throw new System.Exception("It is not a shop");
    }
  }

  private void Update()
  {
    if (_playerProvider.Player == null)
      return;

    float distance = Vector3.Distance(transform.position, _playerProvider.Player.transform.position);

    if (distance < Distance)
    {
      _headsUpDisplayProvider.OpenShopButton.WindowId = WindowId;
      SetButtonPosition(_headsUpDisplayProvider.OpenShopButton);
      IsActive = true;
    }
    else
    {
      IsActive = false;
    }
  }
  
  private void SetButtonPosition(OpenShopButton openShopButton)
  {
    Vector2 screenPoint = _cameraProvider.MainCamera.WorldToScreenPoint(transform.position);

    RectTransformUtility.ScreenPointToLocalPointInRectangle(_headsUpDisplayProvider.CanvasTransform, screenPoint, null, out Vector2 localPoint);

    openShopButton.RectTransform.anchoredPosition = localPoint + Vector2.up * YOffset;
  }
}