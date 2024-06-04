using System.Collections.Generic;
using System.Linq;
using PersistentProgresses;
using Projects;
using UnityEngine;

namespace SaveLoadServices
{
  public class SaveLoadService
  {
    private readonly PersistentProgressService _progressService;
    private readonly ProjectData _projectData;

    public SaveLoadService(PersistentProgressService progressService, ProjectData projectData)
    {
      _progressService = progressService;
      _projectData = projectData;
    }

    public List<IProgressReader> ProgressReaders { get; set; } = new();
    private string ProgressKey => $"{_projectData.GameMode}_progress";

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