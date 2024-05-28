using DataRepositories;
using Infrastructure.AudioServices;
using Infrastructure.Games;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Infrastructure.Upgrades;
using Quests;
using UnityEngine;
using Zenject;

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

    _sceneLoader.Load(ProjectConstants.Scenes.GameLoop);
  }
}