using DG.Tweening;
using UnityEngine;

namespace Grenades
{
  [RequireComponent(typeof(GrenadeDetonator))]
  public class GrenadeMover : MonoBehaviour
  {
    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private GrenadeDetonator _detonator;
    private GrenadeDetonationRadius _detonationRadius;
    private GrenadeConfig _config;

    private float FlightTime => _config.FlightTime;

    public void Init(GrenadeConfig config, Vector3 startPosition, Vector3 targetPosition)
    {
      _startPosition = startPosition;
      _targetPosition = targetPosition;
      _config = config;

      _detonator = GetComponent<GrenadeDetonator>();
      _detonationRadius = GetComponentInChildren<GrenadeDetonationRadius>();
      _detonationRadius.Init(_config);
      _detonationRadius.gameObject.SetActive(false);
    }

    public void Throw()
    {
      MoveGrenade();
    }

    private void MoveGrenade()
    {
      Vector3 initialVelocity = CalculateInitialVelocity();
      float elapsedTime = 0f;

      DOTween
        .To(() => elapsedTime, x => elapsedTime = x, FlightTime, FlightTime)
        .SetEase(Ease.OutQuart)
        .OnUpdate(() =>
        {
          float t = elapsedTime / FlightTime;
          transform.position = CalculatePosition(t, initialVelocity);
        })
        .OnComplete(() =>
        {
          transform.position = _targetPosition;
          _detonator.Detonate();
          _detonationRadius.gameObject.SetActive(true);
        });
    }

    private Vector3 CalculateInitialVelocity()
    {
      Vector3 displacement = _targetPosition - _startPosition;
      Vector3 displacementXZ = new Vector3(displacement.x, 0, displacement.z);

      float time = FlightTime;
      float vxz = displacementXZ.magnitude / time;
      float vy = (displacement.y - 0.5f * Physics.gravity.y * time * time) / time;

      Vector3 result = displacementXZ.normalized * vxz;
      result.y = vy;

      return result;
    }

    private Vector3 CalculatePosition(float t, Vector3 initialVelocity)
    {
      Vector3 result = _startPosition +
                       initialVelocity * t +
                       Physics.gravity * (0.5f * t * t);

      return result;
    }
  }
}