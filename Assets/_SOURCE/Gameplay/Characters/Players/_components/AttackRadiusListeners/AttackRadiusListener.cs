using StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.AttackRadiusListeners
{
  public class AttackRadiusListener : MonoBehaviour
  {
    private RectTransform _rectTransform;

    [Inject] private PlayerWeaponIdProvider _playerWeaponIdProvider;
    [Inject] private IStaticDataService _staticDataService;

    private void Awake()
    {
      _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
      float fireRangeValue = _staticDataService.GetWeaponConfig(_playerWeaponIdProvider.WeaponTypeId).FireRange;

      OnUpgradeChanged(fireRangeValue);
    }

    private void OnUpgradeChanged(float value)
    {
      float radius = value * 2;

      _rectTransform.localScale = new Vector3(radius, radius, radius);
    }
  }
}