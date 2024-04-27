using System;
using Configs.Resources.QuestConfigs.Scripts;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using Quests;
using Quests.Subquests;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows.SubQuestSlots
{
  public class SubQuestSlotsSpawner : MonoBehaviour
  {
    public QuestWindow QuestWindow;

    private IAssetProvider _assetProvider;
    private SubQuestSlot.Factory _factory;

    [Inject]
    private void Construct(IAssetProvider assetProvider, SubQuestSlot.Factory factory)
    {
      _assetProvider = assetProvider;
      _factory = factory;
    }

    private QuestConfig QuestConfig => QuestWindow.Quest.Config;

    private void Start()
    {
      CreateSubQuests();

      QuestWindow.Quest.State.ValueChanged += QuestStateChanged;
    }

    private void QuestStateChanged(QuestState state)
    {
      switch (state)
      {
        case QuestState.Unknown:
          throw new ArgumentOutOfRangeException(nameof(QuestWindow.Quest.State));

        case QuestState.UnActivated:
          break;

        case QuestState.Activated:
          QuestWindow.Quest.SubQuests[0].State.Value = QuestState.Activated;
          break;

        case QuestState.RewardReady:
          break;
      }
    }

    private void CreateSubQuests()
    {
      for (var i = 0; i < QuestConfig.SubQuests.Count; i++)
      {
        SubQuest subQuest = QuestWindow.Quest.SubQuests[i];

        SubQuestSlot slot = _factory.Create(subQuest);

        slot.transform.SetParent(transform);
      }
    }
  }
}