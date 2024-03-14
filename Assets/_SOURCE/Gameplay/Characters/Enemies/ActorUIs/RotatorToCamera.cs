using UnityEngine;

namespace Gameplay.Characters.Enemies.ActorUIs
{
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
      transform.rotation = Camera.main.transform.rotation;
    }
  }
}