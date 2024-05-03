using Configs.Resources.StatConfigs;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.PlayerStatsProviders;
using UnityEngine;
using Zenject;

public class HenPlayerFollower : MonoBehaviour
{
  [Inject] private HenMover _henMover;
  [Inject] private PlayerStatsProvider _playerStatsProvider;
  [Inject] private PlayerProvider _playerProvider;
  [Inject] private HenRotator _henRotator;

  private int MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;
  private Transform Player => _playerProvider.Player.transform;

  private void Update()
  {
    float minDistance = 2f;

    float distance = Vector3.Distance(Player.position, transform.position);

    if (distance > minDistance)
    {
      Vector3 direction = (Player.position - transform.position).normalized;
      _henMover.Move(direction, MoveSpeed);
      _henRotator.Rotate(direction);
    }
  }
}