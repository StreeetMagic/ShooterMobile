using System;
using Characters.Enemies.Configs;
using Characters.Players;
using Characters.Players._components;
using UnityEngine;
using Upgrades;
using Zenject;

namespace Characters.Enemies._components.TargetLocators
{
  public class EnemyTargetLocator : MonoBehaviour
  {
    public SphereCollider SphereCollider;

    [Inject] private UpgradeService _upgradeService;
    [Inject] private EnemyConfig _config;

    public event Action<PlayerTargetTrigger> TargetLocated;
    public event Action<PlayerTargetTrigger> TargetLost;

    private float Radius => _config.ShootRange;
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