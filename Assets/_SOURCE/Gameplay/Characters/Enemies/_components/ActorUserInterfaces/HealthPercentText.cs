using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.ActorUserInterfaces
{
  public class HealthPercentText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private EnemyHealth _enemyHealth;
    [Inject] private EnemyConfig _config;

    private float MaxHealth => _config.InitialHealth;

    private void Start()
    {
      UpdateText(_enemyHealth.Current.Value);
      _enemyHealth.Current.ValueChanged += UpdateText;
    }

    private void OnDestroy()
    {
      _enemyHealth.Current.ValueChanged -= UpdateText;
    }

    private void UpdateText(int current)
    {
      Text.text = Mathf.RoundToInt(current / MaxHealth * 100) + "%";
    }
  }
}