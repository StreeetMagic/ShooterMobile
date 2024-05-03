using Infrastructure.AudioServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.SettingsWindows.MusicToggles
{
  public class MusicToggle : MonoBehaviour
  {
    public Toggle Toggle;

    [Inject] private AudioService _audioService;

    private void Awake()
    {
      Toggle.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnEnable() =>
      Toggle.isOn = !_audioService.IsMusicMuted;

    private void OnValueChanged(bool toggle)
    {
      if (toggle)
        _audioService.UnMuteMusic();
      else
        _audioService.MuteMusic();
    }
  }
}