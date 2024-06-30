using UnityEngine;

namespace Projectiles
{
  public class ProjectileMover
  {
    private float _speed;
    private Vector3 _currentPosition;
    private Vector3 _futurePosition;

    //TODO ебанько, сделай конструктор
    public void Initialize(float speed)
    {
      _speed = speed;
    }

    public bool MoveProjectile(Transform transform, LayerMask layerMask, out RaycastHit hit)
    {
      _currentPosition = transform.position;
      Vector3 direction = transform.forward * (_speed * Time.deltaTime);
      _futurePosition = _currentPosition + direction;

      if (Physics.Linecast(_currentPosition, _futurePosition, out hit, layerMask))
      {
        transform.position = hit.point;
        return false;
      }
      else
      {
        transform.position = _futurePosition;
        return true;
      }
    }
  }
}