using Gameplay.Characters.Questers;
using Maps;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Buttons.OpenQuestButtons
{
  public class OpenQuestButtonController : MonoBehaviour
  {
    public OpenQuestButton OpenQuestButton;

    [Inject] private MapProvider _mapProvider;

    private void Update()
    {
      if (_mapProvider.Map == null)
        return;

      bool isQuesterActive = false;

      foreach (Quester quester in _mapProvider.Map.Questers)
      {
        if (quester.OpenQuestButtonEnabler.IsActive)
        {
          isQuesterActive = true;
          break;
        }
      }

      OpenQuestButton.gameObject.SetActive(isQuesterActive);
    }
  }
}