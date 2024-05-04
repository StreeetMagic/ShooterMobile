using Configs.Resources.StatConfigs;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.PlayerStatsProviders;
using UnityEngine;
using Zenject;

public class HenToPlayerFollower : MonoBehaviour
{
  [Inject] private HenMover _henMover;
  [Inject] private PlayerStatsProvider _playerStatsProvider;
  [Inject] private PlayerProvider _playerProvider;
  [Inject] private HenRotator _henRotator;

  private int MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;
  private Transform Player => _playerProvider.Player.transform;

  private void Update()
  {
    _henMover.Move(Player.position, MoveSpeed);
    _henRotator.Rotate(Player.position);
  }
}