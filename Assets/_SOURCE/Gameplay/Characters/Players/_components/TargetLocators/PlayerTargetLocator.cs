using System.Collections.Generic;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerTargetLocator : ITickable
  {
    private const int MaxTargets = 20;

    private readonly PlayerStatsProvider _playerStatsProvider;
    private readonly PlayerTargetHolder _playerTargetHolder;
    private readonly Collider[] _colliders = new Collider[MaxTargets];
    private readonly Transform _transform;

    public PlayerTargetLocator(PlayerStatsProvider playerStatsProvider,
      PlayerTargetHolder playerTargetHolder, Transform transform)
    {
      _playerStatsProvider = playerStatsProvider;
      _playerTargetHolder = playerTargetHolder;
      _transform = transform;
    }

    private float Radius => _playerStatsProvider.GetStat(StatId.FireRange).Value;

    public void Tick()
    {
      int count = Physics.OverlapSphereNonAlloc(_transform.position, Radius, _colliders);

      var list = new List<ITargetTrigger>();

      for (var index = 0; index < count; index++)
      {
        Collider collider1 = _colliders[index];

        if (collider1.gameObject.TryGetComponent(out ITargetTrigger targetTrigger) == false)
          continue;

        if (targetTrigger.Health.IsDead)
          continue;

        list.Add(targetTrigger);
      }

      _playerTargetHolder.AddTargets(list);
    }
  }
}