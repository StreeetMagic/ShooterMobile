using Gameplay.Characters.Players._components.Factories;
using Gameplay.Characters.Questers;
using Maps;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players._components.ActorUserIntefaces.QuestPointers
{
  public class QuestDistanceText : MonoBehaviour
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
      if (_mapProvider.Map == null)
        return;
      
      Quester quester = _mapProvider.Map.Questers[0];
      Player player = _playerProvider.Player;

      float distance = Vector3.Distance(quester.transform.position, player.transform.position);

      int distanceInt = (int)distance;

      Text.text = distanceInt + " m";
    }
  }
}