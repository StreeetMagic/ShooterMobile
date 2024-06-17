using Gameplay.Characters.Players;
using Gameplay.Weapons;
using Infrastructure.ConfigServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs.Current
{
  public class CurrentWeaponAmmoText : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ConfigService _configService;

    private TextMeshProUGUI _text;

    private void Awake()
    {
      _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
      WeaponTypeId playerCurrentWeaponId = _playerProvider.Instance.WeaponIdProvider.CurrentId.Value;
      WeaponConfig weaponConfig = _configService.GetWeaponConfig(playerCurrentWeaponId);
      int currentAmmo = _playerProvider.Instance.WeaponAmmo.GetAmmo(playerCurrentWeaponId).Value;

      _text.text = currentAmmo + "/" + weaponConfig.MagazineCapacity;
    }
  }
}