using Infrastructure.Games;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class BombDefuseRadius : MonoBehaviour
{
  private RectTransform _rectTransform;

  private void Awake()
  {
    _rectTransform = GetComponent<RectTransform>();
  }

  private void OnEnable()
  {
    float value = Constants.CommonSettings.BombDefuseRadius * 2f;

    _rectTransform.localScale = new Vector3(value, value, value);
  }
}
