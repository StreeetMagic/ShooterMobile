using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Questers;
using Maps;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointers
{
  public class QuestDistanceText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private readonly PlayerProvider _playerProvider;
    [Inject] private readonly MapProvider _mapProvider;

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