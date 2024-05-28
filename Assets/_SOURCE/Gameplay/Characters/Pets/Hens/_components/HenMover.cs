using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Pets.Hens
{
  public class HenMover : MonoBehaviour
  {
    [Inject] private CharacterController _characterController;

    public void Move(Vector3 target, int moveSpeed)
    {
      Vector3 direction = (target - transform.position).normalized;
      _characterController.Move(direction * (moveSpeed * Time.deltaTime));
    }
  }
}