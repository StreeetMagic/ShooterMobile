using Gameplay.Characters.Players;
using Gameplay.Weapons;
using Infrastructure.ArtConfigServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs.Next
{
  public class NextWeaponText : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ArtConfigService _artConfigService;

    private TextMeshProUGUI _text;

    private void Awake()
    {
      _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
      WeaponTypeId weaponTypeId = _playerProvider.Instance.WeaponIdProvider.NextId.Value;

      if (weaponTypeId == WeaponTypeId.Unknown)
        _text.text = "";
      else
        _text.text = _artConfigService.GetWeaponContentSetup(weaponTypeId).Name;
    }
  }
}