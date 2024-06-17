using Gameplay.Weapons;
using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.ActorUserIntefaces
{
  public class AttackRadiusListener : MonoBehaviour
  {
    private RectTransform _rectTransform;

    [Inject] private PlayerWeaponIdProvider _playerWeaponIdProvider;
    [Inject] private ConfigProvider _configProvider;

    private void Awake()
    {
      _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
      OnChanged(_playerWeaponIdProvider.CurrentId.Value);
      _playerWeaponIdProvider.CurrentId.ValueChanged += OnChanged;
    }
    
    private void OnDisable()
    {
      _playerWeaponIdProvider.CurrentId.ValueChanged -= OnChanged;
    }

    private void OnChanged(WeaponTypeId obj)
    {
      float radius = FireRangeValue() * 2;

      _rectTransform.localScale = new Vector3(radius, radius, radius);
    }

    private float FireRangeValue() =>
      _configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).FireRange;
  }
}