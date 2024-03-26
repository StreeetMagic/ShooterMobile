using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Upgrades;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AttackRadiusListener : MonoBehaviour
{
  private PlayerStatsProvider _playerStatsProvider;
  private RectTransform _rectTransform;

  [Inject]
  public void Construct(PlayerStatsProvider playerStatsProvider)

  {
    _playerStatsProvider = playerStatsProvider;
    _rectTransform = GetComponent<RectTransform>();
  }

  private void OnEnable()
  {
    int fireRangeValue = _playerStatsProvider.FireRange.Value;
    Debug.Log(fireRangeValue);
    
    OnUpgradeChanged(fireRangeValue);
    _playerStatsProvider.FireRange.ValueChanged += OnUpgradeChanged;
  }

  private void OnDisable()
  {
    _playerStatsProvider.FireRange.ValueChanged -= OnUpgradeChanged;
  }

  private void Update()
  {
  }

  private void OnUpgradeChanged(int value)
  {
    var radius = value * 2;

    _rectTransform.localScale = new Vector3(radius, radius, radius);
  }
}