using Gameplay.BaseTriggers;
using Maps;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.ActorUserIntefaces.BasePointers
{
  public class BaseDistanceText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    private PlayerProvider _playerProvider;
    private MapProvider _mapProvider;

    [Inject]
    private void Construct(PlayerProvider playerProvider, MapProvider mapProvider)
    {
      _playerProvider = playerProvider;
      _mapProvider = mapProvider;
    }

    private void Update()
    {
      if (_playerProvider.Instance == null)
        return;

      if (_mapProvider.Map == null)
        return;

      BaseTrigger baseTrigger = _mapProvider.Map.BaseTrigger;
      PlayerInstaller player = _playerProvider.Instance;

      float distance = Vector3.Distance(baseTrigger.transform.position, player.transform.position);

      int distanceInt = (int)distance;

      Text.text = distanceInt + " m";
    }
  }
}