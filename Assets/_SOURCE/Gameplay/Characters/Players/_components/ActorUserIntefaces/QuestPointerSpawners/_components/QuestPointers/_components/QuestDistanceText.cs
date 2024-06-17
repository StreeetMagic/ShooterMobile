using System.Linq;
using Gameplay.Quests;
using Maps;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointerSpawners.QuestPointers
{
  public class QuestDistanceText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private readonly PlayerProvider _playerProvider;
    [Inject] private readonly MapProvider _mapProvider;
    [Inject] private readonly QuestConfig _quest;
    [Inject] private readonly QuestTargetsProvider _targetProvider;

    private void Update()
    {
      if (_mapProvider.Map == null)
        return;

      Transform target = _targetProvider.GetTargetsOrNull(_quest.Id)?.FirstOrDefault();
      PlayerInstaller player = _playerProvider.Instance;

      if (target == null || player == null)
        return;

      float distance = Vector3.Distance(target.position, player.transform.position);

      int distanceInt = (int)distance;

      Text.text = distanceInt + " m";
    }
  }
}