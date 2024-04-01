using System;
using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Upgrades;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerTargetLocator : MonoBehaviour
  {
    private const string Player = nameof(Player);

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
      var colliders = Physics.OverlapSphere(transform.position, Radius);

      var list = new List<EnemyTargetTrigger>();

      foreach (var collider in colliders)
      {
        if (!collider.gameObject.TryGetComponent<EnemyTargetTrigger>(out var targetTrigger))
          continue;

        if (targetTrigger.EnemyHealth.IsDead)
          continue;

        list.Add(targetTrigger);
      }
      
      _playerTargetHolder.AddTargets(list);
    }
  }
}