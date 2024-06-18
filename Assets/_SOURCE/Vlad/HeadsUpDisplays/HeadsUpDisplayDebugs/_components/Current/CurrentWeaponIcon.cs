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
    [Inject] private ArtConfigProvider _artConfigProvider;

    private Image _icon;

    private void Awake()
    {
      _icon = GetComponent<Image>();
    }

    private void Update()
    {
      if (!_playerProvider.Instance)
        return;
      
      _icon.sprite = _artConfigProvider.GetWeaponContentSetup(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).Icon;
    }
  }
}
