using UnityEngine;

namespace Characters.Enemies._components.ActorUserInterfaces
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
      Vector3 directionToCamera = _camera.transform.position - Parent.position;
      transform.position = Parent.position + directionToCamera.normalized * Offset;
      transform.position += Vector3.up * HeightOffset;
    }

    private void LookTowardCamera()
    {
      transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward,
        _camera.transform.rotation * Vector3.up);
    }
  }
}