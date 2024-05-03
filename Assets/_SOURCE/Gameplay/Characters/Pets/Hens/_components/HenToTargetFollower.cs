using Configs.Resources.StatConfigs;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.PlayerStatsProviders;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Pets.Hens
{
  public class HenToTargetFollower : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private HenMover _henMover;
    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private HenRotator _henRotator;

    private Transform Target => _playerProvider.PlayerTargetHolder.CurrentTarget.transform;
    private int MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;

    private void Update()
    {
      if (_playerProvider.PlayerTargetHolder.CurrentTarget != null)
      {
        _henMover.Move(Target.position, MoveSpeed);
        _henRotator.Rotate(Target.position);
      }
    }
  }
}