using Gameplay.Characters.Players;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Bombs
{
  public class BombPlayerDetector : MonoBehaviour
  {
    public Bomb Bomb;
    public SphereCollider SphereCollider;
    
    [Inject] private IStaticDataService _staticDataService;

    public bool IsPlayerDetected { get; private set; }

    private void Awake()
    {
      SphereCollider.radius = _staticDataService.GetPlayerConfig().BombDefuseRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out Player player))
      {
        IsPlayerDetected = true;

        var playerBombDefuser = player.GetComponent<PlayerBombDefuser>();

        if (playerBombDefuser.Bombs.Contains(Bomb) == false)
        {
          playerBombDefuser.Bombs.Add(Bomb);
        }
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.TryGetComponent(out Player player))
      {
        IsPlayerDetected = false;
        GetComponent<BombDefuser>().DefuseProgress = 0;

        var playerBombDefuser = player.GetComponent<PlayerBombDefuser>();

        if (playerBombDefuser.Bombs.Contains(Bomb))
        {
          playerBombDefuser.Bombs.Remove(Bomb);
        }
      }
    }
  }
}