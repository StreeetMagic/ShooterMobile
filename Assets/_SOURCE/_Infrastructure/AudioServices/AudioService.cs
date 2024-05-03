using System.Linq;
using Configs.Resources.MusicConfigs.Scripts;
using Configs.Resources.SoundConfigs.Scripts;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;

namespace Infrastructure.AudioServices
{
  public class AudioService : IInitializable, IProgressWriter
  {
    private readonly ProjectZenjectFactory _factory;
    private readonly IStaticDataService _staticDataService;

    private AudioSourceContainer _container;
    private MusicPlayer _musicPlayer;
    private SoundPlayer _soundPlayer;

    public AudioService(ProjectZenjectFactory factory, IStaticDataService staticDataService)
    {
      _factory = factory;
      _staticDataService = staticDataService;
    }

    public bool IsWorking { get; private set; } = true;
    public bool IsMusicMuted { get; private set; }

    public void Initialize()
    {
      _container = _factory.InstantiateMono<AudioSourceContainer>();
      _container.transform.SetParent(null);

      _musicPlayer = _factory.InstantiateNative<MusicPlayer>();
      _soundPlayer = new SoundPlayer();
    }

    public void PlayMusic(MusicId id)
    {
      MusicConfig config = _staticDataService.GetMusicConfig(id);
      AudioSource audioSource = _container.MusicSources[0];

      _musicPlayer.Play(config, audioSource);
    }

    public void PlaySound(SoundId id, Vector3 at = default)
    {
      if (IsWorking == false)
        return;

      SoundConfig config = _staticDataService.GetSoundConfig(id);

      AudioSource source = _container.SoundSources.FirstOrDefault(source => source.isPlaying == false);

      if (source == null)
        return;

      _soundPlayer.Play(config, source, at);
    }

    public void UnMuteMusic()
    {
      _container.MusicSources[0].mute = false;

      IsMusicMuted = false;
    }

    public void MuteMusic()
    {
      _container.MusicSources[0].mute = true;

      IsMusicMuted = true;
    }

    public void ReadProgress(Progress progress)
    {
      bool mute = progress.MusicMute;

      if (mute)
        MuteMusic();
      else
        UnMuteMusic();
    }

    public void WriteProgress(Progress progress)
    {
      progress.MusicMute = IsMusicMuted;
    }
  }
}