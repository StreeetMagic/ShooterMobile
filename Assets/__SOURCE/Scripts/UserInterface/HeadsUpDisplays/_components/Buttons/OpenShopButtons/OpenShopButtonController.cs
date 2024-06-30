using Characters.Shopers;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays._components.Buttons.OpenShopButtons
{
  public class OpenShopButtonController : MonoBehaviour
  {
    public OpenShopButton OpenShopButton;

    [Inject] private MapProvider _mapProvider;

    private void Update()
    {
      if (_mapProvider.Map == null)
        return;

      bool isShoperActive = false;

      foreach (Shoper shoper in _mapProvider.Map.Shopers)
      {
        if (shoper.OpenShopButtonEnabler.IsActive)
        {
          isShoperActive = true;
          break;
        }
      }

      OpenShopButton.gameObject.SetActive(isShoperActive);
    }
  }
}