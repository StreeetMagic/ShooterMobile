using UnityEngine;
using Zenject;

public class HenMover : MonoBehaviour
{
  [Inject] private CharacterController _characterController;

  public void Move(Vector3 direction, int moveSpeed)
  {
    _characterController.Move(direction * moveSpeed * Time.deltaTime);
  }
}