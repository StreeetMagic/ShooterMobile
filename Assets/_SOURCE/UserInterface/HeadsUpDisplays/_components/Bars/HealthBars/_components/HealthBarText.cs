using Gameplay.Characters.Players;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Stats;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Bars.HealthBars._components
{
  public class HealthBarText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private PlayerStatsProvider _playerStatsProvider;

    private void Update()
    {
      if (_playerProvider.PlayerHealth == null)
        return;

      int maxHealth = _playerStatsProvider.GetStat(StatId.Health).Value;
      int currentHealth = _playerProvider.PlayerHealth.Current.Value;

      float healthPercentage = (float)currentHealth / maxHealth * 100;

      Text.text = $"HP {healthPercentage}%";
    }
  }
}