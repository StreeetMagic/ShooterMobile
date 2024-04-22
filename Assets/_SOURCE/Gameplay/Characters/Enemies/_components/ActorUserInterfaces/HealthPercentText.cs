using System;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Healths;
using TMPro;
using UnityEngine;
using Zenject;

public class HealthPercentText : MonoBehaviour
{
  public TextMeshProUGUI Text;

  private Enemy _enemy;
  private EnemyHealth _enemyHealth;

  [Inject]
  private void Construct(Enemy enemy, EnemyHealth enemyHealth)
  {
    _enemy = enemy;
    _enemyHealth = enemyHealth;
  }

  private float MaxHealth => _enemy.Config.InitialHealth;

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