using System;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Upgrades;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerTargetLocator : MonoBehaviour
  {
    private const string Player = nameof(Player);

    public SphereCollider SphereCollider;

    private UpgradeService _upgradeService;

    [Inject]
    public void Construct(UpgradeService upgradeService)
    {
      _upgradeService = upgradeService;
    }

    public event Action<TargetTrigger> TargetLocated;
    public event Action<TargetTrigger> TargetLost;

    private float Radius => _upgradeService.GetCurrentUpgradeValue(UpgradeId.AttackRadius);

    private void OnEnable()
    {
      OnUpgradeChanged();

      _upgradeService.Changed += OnUpgradeChanged;
    }

    private void OnDisable()
    {
      _upgradeService.Changed -= OnUpgradeChanged;
    }

    private void OnUpgradeChanged()
    {
      SphereCollider.radius = Radius / 2;
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