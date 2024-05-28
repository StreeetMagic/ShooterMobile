using System.Collections.Generic;
using _Infrastructure.Projects;
using Gameplay.Bombs;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.BombDefusers
{
  public class PlayerBombDefuser : MonoBehaviour
  {
    public List<Bomb> Bombs { get; } = new();

    [Inject] private PlayerHealth _playerHealth;
    [Inject] private PlayerMoveSpeed _playerMoveSpeed;

    private void OnEnable()
    {
      _playerHealth.Damaged += OnDamaged;
    }

    private void OnDisable()
    {
      _playerHealth.Damaged -= OnDamaged;
    }

    private void OnDamaged(int obj)
    {
      if (Bombs.Count > 0)
      {
        if (Bombs[0] != null)
        {
          Bombs[0].GetComponent<BombDefuser>().DefuseProgress = 0;
        }
      }
    }

    private void Update()
    {
      if (_playerMoveSpeed.CurrentMoveSpeed.Value == 0)
      {
        float progressPerFrame = (Time.deltaTime / ProjectConstants.CommonSettings.BombDefuseDuration);

        if (Bombs.Count > 0)
        {
          if (Bombs[0] != null)
          {
            Bombs[0].GetComponent<BombDefuser>().DefuseProgress += progressPerFrame;
          }
        }
      }
      else
      {
        if (Bombs.Count > 0)
        {
          if (Bombs[0] != null)
          {
            Bombs[0].GetComponent<BombDefuser>().DefuseProgress = 0;
          }
        }
      }
    }
  }
}