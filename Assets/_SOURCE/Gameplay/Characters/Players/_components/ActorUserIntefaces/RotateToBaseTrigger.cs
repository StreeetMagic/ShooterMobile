using System.Collections;
using System.Collections.Generic;
using Gameplay.BaseTriggers;
using Infrastructure.Utilities;
using Maps;
using UnityEngine;
using Zenject;

public class RotateToBaseTrigger : MonoBehaviour
{
  public Canvas Canvas;

  private MapProvider _mapProvider;

  [Inject]
  public void Construct(MapProvider mapProvider)
  {
    _mapProvider = mapProvider;
  }

  private BaseTrigger BaseTrigger => _mapProvider.Map.BaseTrigger;

  private void LateUpdate()
  {
    RotateToBase();

    Hide();
  }

  private void RotateToBase()
  {
    transform.rotation = Quaternion.LookRotation(transform.position - BaseTrigger.transform.position);

    Quaternion cachedRotation = transform.rotation;

    transform.rotation = new Quaternion(0, cachedRotation.y, 0, cachedRotation.w);
  }

  private void Hide()
  {
    const float MinDistance = 7;

    var distance = Vector3.Distance(transform.position, BaseTrigger.transform.position);

    Canvas.enabled = !(distance < MinDistance);
  }
}