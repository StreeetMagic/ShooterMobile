using Characters.Players;
using Characters.Players._components;
using Infrastructure.ConfigProviders;
using UnityEngine;
using Zenject;

namespace Bombs
{
  public class BombPlayerDetector : MonoBehaviour
  {
    public Bomb Bomb;
    public SphereCollider SphereCollider;
    
    [Inject] private ConfigProvider _configProvider;

    public bool IsPlayerDetected { get; private set; }

    private void Awake()
    {
      SphereCollider.radius = _configProvider.PlayerConfig.BombDefuseRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out PlayerInstaller player))
      {
        IsPlayerDetected = true;

        PlayerBombDefuser playerBombDefuser = player.BombDefuser;

        if (playerBombDefuser.Bombs.Contains(Bomb) == false)
        {
          playerBombDefuser.Bombs.Add(Bomb);
        }
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.TryGetComponent(out PlayerInstaller player))
      {
        IsPlayerDetected = false;
        GetComponent<BombDefuser>().DefuseProgress = 0;

        PlayerBombDefuser playerBombDefuser = player.BombDefuser; 

        if (playerBombDefuser.Bombs.Contains(Bomb))
        {
          playerBombDefuser.Bombs.Remove(Bomb);
        }
      }
    }
  }
}