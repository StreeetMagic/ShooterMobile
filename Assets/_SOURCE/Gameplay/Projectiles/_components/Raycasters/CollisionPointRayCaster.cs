using UnityEngine;

namespace Gameplay.Projectiles.Raycasters
{
  public class CollisionPointRayCaster : MonoBehaviour
  {
    private Vector3 _previousPosition = Vector3.zero;
    private Vector3 _currentPosition;
    
    public Vector3 HitPosition;

    private void FixedUpdate()
    {
      UpdatePositions();
      CastRay();
    }

    private void CastRay()
    {
      if (_previousPosition == _currentPosition)
        return;

      if (_previousPosition == Vector3.zero)
        return;

      if (Physics.Linecast(_previousPosition, _currentPosition, out var hit))
      {
        HitPosition = hit.point;
      }
    }

    private void UpdatePositions()
    {
      _previousPosition = _currentPosition;
      _currentPosition = transform.position;
    }
  }
}