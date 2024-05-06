using Configs.Resources.StatConfigs;
using Gameplay.Characters.Pets.Hens.MeshModels;
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
    [Inject] private HenAnimator _henAnimator;

    private float _timeLeft;

    private Transform Target => _playerProvider.PlayerTargetHolder.CurrentTarget.transform;
    private int MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;

    private void Awake()
    {
      enabled = false;
    }

    private void OnEnable()
    {
      var delay = _henAnimator.PlayAlarmAnimation();

      _timeLeft = delay;
    }

    private void Update()
    {
      _timeLeft -= Time.deltaTime;

      if (_timeLeft <= 0)
      {
        if (_playerProvider.PlayerTargetHolder.CurrentTarget != null)
        {
          _henMover.Move(Target.position, MoveSpeed);
          _henRotator.Rotate(Target.position);
        }
      }
    }
  }
}