using System.Collections.Generic;
using Configs.Resources.StatConfigs;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Characters.Players.TargetHolders;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerTargetLocator : MonoBehaviour
  {
    private const int MaxTargets = 20;

    private PlayerStatsProvider _playerStatsProvider;
    private PlayerTargetHolder _playerTargetHolder;
    private Collider[] _colliders;

    [Inject]
    public void Construct(PlayerStatsProvider playerStatsProvider, PlayerTargetHolder playerTargetHolder)
    {
      _playerStatsProvider = playerStatsProvider;
      _playerTargetHolder = playerTargetHolder;
      _colliders = new Collider[MaxTargets];
    }

    private float Radius => _playerStatsProvider.GetStat(StatId.FireRange).Value;

    private void Update()
    {
      Scan();
    }

    private void Scan()
    {
      int count = Physics.OverlapSphereNonAlloc(transform.position, Radius, _colliders);

      var list = new List<EnemyTargetTrigger>();

      for (var index = 0; index < count; index++)
      {
        Collider collider1 = _colliders[index];

        if (collider1.gameObject.TryGetComponent(out EnemyTargetTrigger targetTrigger) == false)
          continue;

        if (targetTrigger.EnemyHealth.IsDead)
          continue;

        list.Add(targetTrigger);
      }

      _playerTargetHolder.AddTargets(list);
    }
  }
}