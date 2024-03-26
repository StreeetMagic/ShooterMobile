using System;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Upgrades;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerTargetLocator : MonoBehaviour
  {
    private const string Player = nameof(Player);

    public SphereCollider SphereCollider;

    private PlayerStatsProvider _playerStatsProvider;
    private UpgradeService _upgradeService;

    [Inject]
    public void Construct(UpgradeService upgradeService, PlayerStatsProvider playerStatsProvider)
    {
      _upgradeService = upgradeService;
      _playerStatsProvider = playerStatsProvider;
    }

    public event Action<TargetTrigger> TargetLocated;
    public event Action<TargetTrigger> TargetLost;

    private float Radius => _playerStatsProvider.FireRange.Value;

    private void Start()
    {
      OnUpgradeChanged();

      _upgradeService.Changed += OnUpgradeChanged;
    }

    private void OnDestroy()
    {
      _upgradeService.Changed -= OnUpgradeChanged;
    }

    private void OnUpgradeChanged()
    {
      SphereCollider.radius = Radius;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out TargetTrigger targetTrigger))
      {
        if (targetTrigger.CompareTag(Player))
          return;

        TargetLocated?.Invoke(targetTrigger);
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.TryGetComponent(out TargetTrigger targetTrigger))
      {
        if (targetTrigger.CompareTag(Player))
          return;

        TargetLost?.Invoke(targetTrigger);
      }
    }
  }
}