using Infrastructure.AudioServices.Sounds;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.ZenjectFactories.ProjectContext;
using UnityEngine;
using Zenject;

namespace Infrastructure.AudioServices
{
  public class AudioService : IInitializable, IProgressWriter
  {
    private readonly ProjectZenjectFactory _factory;

    private AudioSourceContainer _container;
   // private MusicPlayer _musicPlayer;

    // ReSharper disable once NotAccessedField.Local
    private SoundPlayer _soundPlayer;

    public AudioService(ProjectZenjectFactory factory)
    {
      _factory = factory;
    }

   // public bool IsWorking { get; private set; } = true;
    public bool IsMusicMuted { get; private set; }

    public void Initialize()
    {
      _container = _factory.InstantiateMono<AudioSourceContainer>();
      _container.transform.SetParent(null);

    //  _musicPlayer = _factory.InstantiateNative<MusicPlayer>();
      _soundPlayer = new SoundPlayer();
    }

    // public void PlayMusic(MusicId id)
    // {
    //   MusicConfig config = null;
    //   AudioSource audioSource = _container.MusicSources[0];
    //
    //   _musicPlayer.Play(config, audioSource);
    // }

    public void PlaySound(SoundId id, Vector3 at = default)
    {
      // if (IsWorking == false)
      //   return;
      //
      // SoundConfig config = _staticDataService.GetSoundConfig(id);
      //
      // AudioSource source = _container.SoundSources.FirstOrDefault(source => source.isPlaying == false);
      //
      // if (source == null)
      //   return;
      //
      // _soundPlayer.Play(config, source, at);
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

    public void ReadProgress(ProjectProgress projectProgress)
    {
      bool mute = projectProgress.MusicMute;

      if (mute)
        MuteMusic();
      else
        UnMuteMusic();
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.MusicMute = IsMusicMuted;
    }
  }
}