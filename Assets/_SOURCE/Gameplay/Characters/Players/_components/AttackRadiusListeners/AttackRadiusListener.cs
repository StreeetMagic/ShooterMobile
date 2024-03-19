using System.Collections;
using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Upgrades;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AttackRadiusListener : MonoBehaviour
{
  private UpgradeService _upgradeService;
  private RectTransform _rectTransform;

  [Inject]
  public void Construct(UpgradeService upgradeService)
  {
    _upgradeService = upgradeService;
  }

  private void OnEnable()
  {
    _rectTransform = GetComponent<RectTransform>();

    _upgradeService.Changed += OnUpgradeChanged;
    
    OnUpgradeChanged();
  }

  private void OnDisable()
  {
    _upgradeService.Changed -= OnUpgradeChanged;
  }

  private void OnUpgradeChanged()
  {
    float radius = _upgradeService.GetCurrentUpgradeValue(UpgradeId.FireRange);


    _rectTransform.localScale = new Vector3(radius, radius, radius);
  }
}