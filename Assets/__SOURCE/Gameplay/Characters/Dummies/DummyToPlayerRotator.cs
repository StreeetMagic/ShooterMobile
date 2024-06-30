using Gameplay.Characters.Players;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Dummies
{
  public class DummyToPlayerRotator : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;

    private void Update()
    {
      RotateToPlayer();
    }

    private void RotateToPlayer()
    {
      transform.LookAt(_playerProvider.Instance.transform);
    }
  }
}