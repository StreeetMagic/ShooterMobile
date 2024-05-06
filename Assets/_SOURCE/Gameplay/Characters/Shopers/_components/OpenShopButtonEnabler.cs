using Gameplay.Characters.Players.Factories;
using Infrastructure.UserIntefaces;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

public class OpenShopButtonEnabler : MonoBehaviour
{
  public const float Distance = 4;

  public WindowId WindowId;
  public bool IsActive;

  [Inject] private PlayerProvider _playerProvider;
  [Inject] private HeadsUpDisplayProvider _headsUpDisplayProvider;

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
      IsActive = true;
    }
    else
    {
      IsActive = false;
    }
  }
}