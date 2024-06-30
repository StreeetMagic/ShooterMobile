using UnityEngine;

namespace Utilities
{
  public static class AngleChanger
  {
    public static Vector3 AddAngle(Vector3 directionToTarget, float angle)
    {
      float randomHorizontalAngle = Random.Range(-angle, angle);
      float randomVerticalAngle = Random.Range(-angle, angle);

      Quaternion horizontalRotation = Quaternion.AngleAxis(randomHorizontalAngle, Vector3.up);
      Quaternion verticalRotation = Quaternion.AngleAxis(randomVerticalAngle, Vector3.right);

      directionToTarget = horizontalRotation * directionToTarget;
      directionToTarget = verticalRotation * directionToTarget;

      return directionToTarget.normalized;
    }
  }
}