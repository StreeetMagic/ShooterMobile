using System;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Upgrades;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetLocators
{
  public class EnemyTargetLocator : MonoBehaviour
  {
    public SphereCollider SphereCollider;

    private Enemy _enemy;
    private UpgradeService _upgradeService;

    [Inject]
    public void Construct(UpgradeService upgradeService, Enemy enemy)
    {
      _upgradeService = upgradeService;

      _enemy = enemy;
    }

    public event Action<PlayerTargetTrigger> TargetLocated;
    public event Action<PlayerTargetTrigger> TargetLost;

    private float Radius => _enemy.Config.Radius;
    public bool HasTarget { get; set; }

    private void Start()
    {
      HasTarget = false;

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
      if (!other.TryGetComponent(out Player player))
        return;

      var targetTrigger = player.GetComponentInChildren<PlayerTargetTrigger>();
      TargetLocated?.Invoke(targetTrigger);

      HasTarget = true;
    }

    private void OnTriggerExit(Collider other)
    {
      if (!other.TryGetComponent(out Player player))
        return;

      var targetTrigger = player.GetComponentInChildren<PlayerTargetTrigger>();
      TargetLost?.Invoke(targetTrigger);

      HasTarget = false;
    }
  }
}