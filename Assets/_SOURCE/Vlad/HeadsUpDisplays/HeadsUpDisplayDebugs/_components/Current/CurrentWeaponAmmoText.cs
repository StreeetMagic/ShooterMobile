using Gameplay.Characters.Players;
using Gameplay.Weapons;
using Infrastructure.ConfigProviders;
using TMPro;
using UnityEngine;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs.Current
{
  public class CurrentWeaponAmmoText : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ConfigProvider _configProvider;

    private TextMeshProUGUI _text;

    private void Awake()
    {
      _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
      if (!_playerProvider.Instance)
        return;
      
      WeaponTypeId playerCurrentWeaponId = _playerProvider.Instance.WeaponIdProvider.CurrentId.Value;
      WeaponConfig weaponConfig = _configProvider.GetWeaponConfig(playerCurrentWeaponId);
      int currentAmmo = _playerProvider.Instance.WeaponAmmo.GetAmmo(playerCurrentWeaponId).Value;

      _text.text = currentAmmo + "/" + weaponConfig.MagazineCapacity;
    }
  }
}