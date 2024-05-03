using Gameplay.Characters.Players.Factories;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Pets.Hens._components
{
  public class HenBehaviourController : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private HenToPlayerFollower _henToPlayerFollower;
    [Inject] private HenToTargetFollower _henToTargetFollower;

    private bool HasTarget => _playerProvider.PlayerTargetHolder.HasTarget;

    private void Update()
    {
      if (HasTarget)
      {
        _henToTargetFollower.enabled = true;
        _henToPlayerFollower.enabled = false;
      }
      else
      {
        _henToTargetFollower.enabled = false;
        _henToPlayerFollower.enabled = true;
      }
    }
  }
}