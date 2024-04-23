using DataRepositories.Quests;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.Factories;
using Maps;
using TMPro;
using UnityEngine;
using Zenject;

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
    Quester quester = _mapProvider.Map.Questers[0];
    Player player = _playerProvider.Player;

    float distance = Vector3.Distance(quester.transform.position, player.transform.position);

    int distanceInt = (int)distance;

    Text.text = distanceInt + " m";
  }
}