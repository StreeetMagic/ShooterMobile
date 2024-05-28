using Gameplay.Characters.Questers;
using Gameplay.Quests;
using Maps;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointerSpawners.QuestPointers._components
{
  public class QuestDistanceText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private readonly PlayerProvider _playerProvider;
    [Inject] private readonly MapProvider _mapProvider;
    [Inject] private readonly Quest _quest;

    private void Update()
    {
      if (_mapProvider.Map == null)
        return;

      Quester quester = _mapProvider.Map.Questers[_quest.Index];
      Player player = _playerProvider.Player;

      float distance = Vector3.Distance(quester.transform.position, player.transform.position);

      int distanceInt = (int)distance;

      Text.text = distanceInt + " m";
    }
  }
}