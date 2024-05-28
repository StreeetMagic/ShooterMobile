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

    public void DeleteSaves()
    {
      PlayerPrefs.DeleteKey(ProgressKey);
    }

    private void UpdateProgressReaders()
    {
      foreach (IProgressReader progressReader in ProgressReaders)
      {
        progressReader.ReadProgress(_progressService.ProjectProgress);
      }
    }

    private void UpdateProgressWriters() =>
      ProgressReaders
        .OfType<IProgressWriter>()
        .ToList()
        .ForEach(progressWriter => progressWriter.WriteProgress(_progressService.ProjectProgress));

    private void WritePlayerPrefs() =>
      PlayerPrefs.SetString(ProgressKey, JsonUtility.ToJson(_progressService.ProjectProgress));

    private void ReadPlayerPrefs()
    {
      if (PlayerPrefs.HasKey(ProgressKey))
        _progressService.LoadProgress(PlayerPrefs.GetString(ProgressKey));
      else
        _progressService.SetDefault();
    }
  }
}