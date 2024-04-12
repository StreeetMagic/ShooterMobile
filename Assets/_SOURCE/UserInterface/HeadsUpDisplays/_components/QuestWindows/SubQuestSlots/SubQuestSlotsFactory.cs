using System;
using Configs.Resources.QuestConfigs;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays.QuestWindows;
using Zenject;

public class SubQuestSlotsFactory : MonoBehaviour
{
  public QuestWindow QuestWindow;

  private IAssetProvider _assetProvider;
  private ProjectZenjectFactory _factory;

  [Inject]
  private void Construct(IAssetProvider assetProvider, ProjectZenjectFactory factory)
  {
    _factory = factory;
    _assetProvider = assetProvider;
  }

  private QuestConfig QuestConfig => QuestWindow.QuestConfig;

  private void Start()
  {
    for (var i = 0; i < QuestConfig.SubQuests.Count; i++)
    {
      SubQuestSetup subQuest = QuestConfig.SubQuests[i];

      SubQuestSlot prefab = _assetProvider.Get<SubQuestSlot>();

      SubQuestSlot slot = _factory.InstantiateMono(prefab, transform);
    }
  }
}