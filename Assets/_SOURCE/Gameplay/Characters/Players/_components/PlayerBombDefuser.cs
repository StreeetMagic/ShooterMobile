using System.Collections.Generic;
using Gameplay.Bombs;
using StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerBombDefuser : MonoBehaviour
  {
    public List<Bomb> Bombs { get; } = new();

    [Inject] private PlayerHealth _playerHealth;
    [Inject] private PlayerMoveSpeed _playerMoveSpeed;
    [Inject] private IStaticDataService _staticDataService;

    private void OnEnable()
    {
      _playerHealth.Damaged += OnDamaged;
    }

    private void OnDisable()
    {
      _playerHealth.Damaged -= OnDamaged;
    }

    private void OnDamaged(float obj)
    {
      if (Bombs.Count <= 0)
        return;

      if (Bombs[0] != null)
        Bombs[0].GetComponent<BombDefuser>().DefuseProgress = 0;
    }

    private void Update()
    {
      if (_playerMoveSpeed.CurrentMoveSpeed.Value == 0)
      {
        float progressPerFrame = (Time.deltaTime / _staticDataService.GetPlayerConfig().BombDefuseDuration);

        if (Bombs.Count <= 0)
          return;

        if (Bombs[0] != null)
          Bombs[0].GetComponent<BombDefuser>().DefuseProgress += progressPerFrame;
      }
      else
      {
        if (Bombs.Count <= 0)
          return;

        if (Bombs[0] != null)
          Bombs[0].GetComponent<BombDefuser>().DefuseProgress = 0;
      }
    }
  }
}