using System.Collections.Generic;
using Configs.Resources.StatConfigs;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players._components.PlayerStatsProviders;
using Gameplay.Characters.Players._components.TargetHolders;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players._components.TargetLocators
{
  public class PlayerTargetLocator : MonoBehaviour
  {
    private PlayerStatsProvider _playerStatsProvider;
    private PlayerTargetHolder _playerTargetHolder;

    [Inject]
    public void Construct(PlayerStatsProvider playerStatsProvider, PlayerTargetHolder playerTargetHolder)
    {
      _playerStatsProvider = playerStatsProvider;
      _playerTargetHolder = playerTargetHolder;
    }

    private float Radius => _playerStatsProvider.GetStat(StatId.FireRange).Value;

    private void Update()
    {
      Scan();
    }

    private void Scan()
    {
      Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);

      var list = new List<EnemyTargetTrigger>();

      foreach (Collider collider1 in colliders)
      {
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