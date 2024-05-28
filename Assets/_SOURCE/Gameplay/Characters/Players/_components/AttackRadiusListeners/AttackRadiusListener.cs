using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.AttackRadiusListeners
{
  public class AttackRadiusListener : MonoBehaviour
  {
    private RectTransform _rectTransform;

    [Inject] private PlayerStatsProvider _playerStatsProvider;

    private void Awake()
    {
      _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
      float fireRangeValue = _playerStatsProvider.GetStat(StatId.FireRange).Value;

      OnUpgradeChanged(fireRangeValue);
      _playerStatsProvider.GetStat(StatId.FireRange).ValueChanged += OnUpgradeChanged;
    }

    private void OnDisable()
    {
      _playerStatsProvider.GetStat(StatId.FireRange).ValueChanged -= OnUpgradeChanged;
    }

    private void OnUpgradeChanged(float value)
    {
      float radius = value * 2;

      _rectTransform.localScale = new Vector3(radius, radius, radius);
    }
  }
}