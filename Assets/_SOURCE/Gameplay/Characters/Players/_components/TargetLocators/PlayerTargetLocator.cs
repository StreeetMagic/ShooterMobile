using System.Collections.Generic;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerTargetLocator : MonoBehaviour
  {
    private const int MaxTargets = 20;

    private readonly Collider[] _colliders = new Collider[MaxTargets];

    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private PlayerTargetHolder _playerTargetHolder;

    private float Radius => _playerStatsProvider.GetStat(StatId.FireRange).Value;

    private void Update()
    {
      Scan();
    }

    private void Scan()
    {
      int count = Physics.OverlapSphereNonAlloc(transform.position, Radius, _colliders);

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