using Configs.Resources.StatConfigs;
using Gameplay.Characters.Players._components.PlayerStatsProviders;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players._components.AttackRadiusListeners
{
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
      int fireRangeValue = _playerStatsProvider.GetStat(StatId.FireRange).Value;

      OnUpgradeChanged(fireRangeValue);
      _playerStatsProvider.GetStat(StatId.FireRange).ValueChanged += OnUpgradeChanged;
    }

    private void OnDisable()
    {
      _playerStatsProvider.GetStat(StatId.FireRange).ValueChanged -= OnUpgradeChanged;
    }

    private void OnUpgradeChanged(int value)
    {
      var radius = value * 2;

      _rectTransform.localScale = new Vector3(radius, radius, radius);
    }
  }
}