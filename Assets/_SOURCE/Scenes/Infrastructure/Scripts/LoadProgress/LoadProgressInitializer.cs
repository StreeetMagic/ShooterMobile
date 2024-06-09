using System;
using AudioServices;
using Gameplay.CurrencyRepositories;
using Gameplay.Quests;
using Gameplay.Upgrades;
using Projects;
using SaveLoadServices;
using SceneLoaders;
using Scenes;
using UnityEngine;
using Zenject;

namespace SceneInstallers.LoadProgress
{
  public class LoadProgressInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SaveLoadService _saveLoadService;
    [Inject] private SceneLoader _sceneLoader;
    [Inject] private MoneyInBankStorage _moneyInBankStorage;
    [Inject] private UpgradeService _upgradeService;
    [Inject] private AudioService _audioService;
    [Inject] private QuestStorage _questStorage;
    [Inject] private EggsInBankStorage _eggsInBankStorage;
    [Inject] private ProjectData _projectData;

    public void Initialize()
    {
      _saveLoadService.ProgressReaders.Add(_moneyInBankStorage);
      _saveLoadService.ProgressReaders.Add(_upgradeService);
      _saveLoadService.ProgressReaders.Add(_audioService);
      _saveLoadService.ProgressReaders.Add(_questStorage);
      _saveLoadService.ProgressReaders.Add(_eggsInBankStorage);

      _saveLoadService.LoadProgress();

      switch (_projectData.SceneId)
      {
        case SceneId.Unknown:
          throw new Exception("Unknown scene id");

        case SceneId.CoreDust:
          _sceneLoader.Load(SceneId.CoreDust.ToString());
          break;

        case SceneId.VladTestScene:
          _sceneLoader.Load(SceneId.VladTestScene.ToString());
          break;

        case SceneId.SimeonTestScene:
          _sceneLoader.Load(SceneId.SimeonTestScene.ToString());
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}