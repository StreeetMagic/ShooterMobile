using System.Collections.Generic;
using System.Linq;
using Infrastructure.PersistentProgresses;
using UnityEngine;

namespace Infrastructure.SaveLoadServices
{
  public class SaveLoadService
  {
    private const string ProgressKey = nameof(ProgressKey);
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

    private void UpdateProgressReaders() =>
      ProgressReaders
        .ForEach(progressReader => progressReader.ReadProgress(_progressService.Progress));

    private void UpdateProgressWriters() =>
      ProgressReaders
        .OfType<IProgressWriter>()
        .ToList()
        .ForEach(progressWriter => progressWriter.WriteProgress(_progressService.Progress));

    private void WritePlayerPrefs() =>
      PlayerPrefs.SetString(ProgressKey, JsonUtility.ToJson(_progressService.Progress));

    private void ReadPlayerPrefs()
    {
      if (PlayerPrefs.HasKey(ProgressKey))
        _progressService.LoadProgress(PlayerPrefs.GetString(ProgressKey));
      else
        _progressService.SetDefault();
    }
  }
}