using Gameplay.Characters.Players;
using Infrastructure.ArtConfigServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs.Current
{
  public class CurrentWeaponIcon : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ArtConfigService _artConfigService;

    private Image _icon;

    private void Awake()
    {
      _icon = GetComponent<Image>();
    }

    private void Update()
    {
      _icon.sprite = _artConfigService.GetWeaponContentSetup(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).Icon;
    }
  }
}
