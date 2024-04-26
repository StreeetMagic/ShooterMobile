using System.Linq;
using Maps;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.OpenQuestButtons
{
  public class OpenQuestButtonController : MonoBehaviour
  {
    public OpenQuestButton OpenQuestButton;

    private MapProvider _mapProvider;

    [Inject]
    private void Construct(MapProvider mapProvider)
    {
      _mapProvider = mapProvider;
    }

    private void Update()
    {
      bool isQuesterActive =
        _mapProvider
          .Map
          .Questers
          .Any(quester => quester.OpenQuestButtonEnabler.IsActive);

      OpenQuestButton
        .gameObject
        .SetActive(isQuesterActive);
    }
  }
}