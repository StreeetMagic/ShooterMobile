using UnityEngine;

public class RotatorToCamera : MonoBehaviour
{
  private Camera _camera;

  private void Awake()
  {
    _camera = Camera.main; 
  }

  public void LateUpdate()
  {
    LookTowardCamera();
  }

  private void LookTowardCamera()
  {
     
  }
}