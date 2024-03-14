using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Characters.Enemies.ActorUIs
{
  public class RotatorToCamera : MonoBehaviour
  {
    public Transform Parent;

    [Tooltip("Расстояние на которое нужно приблизиться к камере")]
    public float Offset;

    [Tooltip("Расстояние на которое нужно поднять по высоте")]
    public float HeightOffset;

    private Camera _camera;

    private void Awake()
    {
      _camera = Camera.main;
    }

    private void LateUpdate()
    {
      MoveCloserToCamera();
      LookTowardCamera();
    }

    private void MoveCloserToCamera()
    {
      if (_camera == null || Parent == null)
        return;

      Vector3 directionToCamera = _camera.transform.position - Parent.position;
      transform.position = Parent.position + directionToCamera.normalized * Offset;
      transform.position += Vector3.up * HeightOffset; // Добавлено смещение по высоте
    }

    private void LookTowardCamera()
    {
      transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward,
        _camera.transform.rotation * Vector3.up);
    }
  }
}