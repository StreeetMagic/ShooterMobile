using System.Collections.Generic;
using Infrastructure.PersistentProgresses;
using UnityEngine;

namespace Infrastructure.SaveLoadServices
{
  public class SaveLoadService
  {
    private const string Key = "Progress";

    private readonly PersistentProgressService _progressService;

    public SaveLoadService(PersistentProgressService progressService)
    {
      _progressService = progressService;
    }

    public List<IProgressReader> ProgressReaders { get; } = new();

    public void SaveProgress()
    {
      UpdateProgressWriters();
      
      WritePlayerPrefs();
    }

    public void LoadProgress()
    {
      ReadPlayerPrefs();

      UpdateProgressReaders();
    }

    private void UpdateProgressReaders()
    {
      foreach (var progressReader in ProgressReaders)
        progressReader.ReadProgress(_progressService.Progress);
    }

    private void UpdateProgressWriters()
    {
      foreach (IProgressReader progressReader in ProgressReaders)
        if (progressReader is IProgressWriter writer)
          writer.WriteProgress(_progressService.Progress);
    }

    private void WritePlayerPrefs() =>
      PlayerPrefs.SetString(Key, JsonUtility.ToJson(_progressService.Progress));

    private void ReadPlayerPrefs()
    {
      if (PlayerPrefs.HasKey(Key))
        _progressService.LoadProgress(PlayerPrefs.GetString(Key));
      else
        _progressService.SetDefault();
    }
  }

  public interface IProgressReader
  {
    void ReadProgress(Progress progress);
  }

  public interface IProgressWriter : IProgressReader
  {
    void WriteProgress(Progress progress);
  }
}