using AudioServices;
using CurrencyRepositories;
using Gameplay.Quests;
using Gameplay.Upgrades;
using Projects;
using SaveLoadServices;
using SceneLoaders;
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

    public void Initialize()
    {
      _saveLoadService.ProgressReaders.Add(_moneyInBankStorage);
      _saveLoadService.ProgressReaders.Add(_upgradeService);
      _saveLoadService.ProgressReaders.Add(_audioService);
      _saveLoadService.ProgressReaders.Add(_questStorage);
      _saveLoadService.ProgressReaders.Add(_eggsInBankStorage);

      _saveLoadService.LoadProgress();

      _sceneLoader.Load(ProjectConstants.Scenes.ChooseGameMode);
    }
  }
}