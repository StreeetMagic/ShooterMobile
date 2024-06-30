using Characters.Players;
using Characters.Players._components;
using Stats;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays._components.Bars.HealthBars._components
{
  public class HealthBarText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private PlayerStatsProvider _playerStatsProvider;

    private void Update()
    {
      if (_playerProvider.Instance == null)
        return;

      float maxHealth = _playerStatsProvider.GetStat(StatId.Health);
      float currentHealth = _playerProvider.Instance.Health.Current.Value;

      float healthPercentage = currentHealth / maxHealth * 100;

      Text.text = $"HP {healthPercentage}%";
    }
  }
}