using System.Collections.Generic;
using Configs.Resources.QuestConfigs;
using Configs.Resources.UpgradeConfigs.Scripts;
using DataRepositories.Quests;
using Infrastructure.StaticDataServices;
using Quests;
using UnityEngine;

namespace Infrastructure.PersistentProgresses
{
  public class PersistentProgressService
  {
    private readonly IStaticDataService _staticDataService;

    public PersistentProgressService(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public Progress Progress { get; private set; }

    public void LoadProgress(string getString) =>
      Progress =
        JsonUtility
          .FromJson<Progress>(getString);

    public void SetDefault()
    {
      Progress = new Progress();

      Progress.MoneyInBank = 500;
      Progress.EggsInBank = 0;
      Progress.PlayerPosition = Vector3.zero;
      Progress.Expierience = 0;
      Progress.MusicMute = false;

      Upgrades();
      Quests();
    }

    private void Upgrades()
    {
      Progress.Upgrades = new List<UpgradeProgress>();

      Dictionary<StatId, UpgradeConfig> upgrades =
        _staticDataService
          .GetUpgradeConfigs();

      foreach (KeyValuePair<StatId, UpgradeConfig> upgrade in upgrades)
        Progress
          .Upgrades
          .Add(new UpgradeProgress(upgrade.Key, 0));
    }

    private void Quests()
    {
      Progress.Quests = new List<QuestProgress>();

      Dictionary<QuestId, QuestConfig> quests =
        _staticDataService
          .GetQuestConfigs();

      foreach (KeyValuePair<QuestId, QuestConfig> quest in quests)
      {
        List<SubQuestProgress> subQuests = new List<SubQuestProgress>();

        for (var i = 0; i < quest.Value.SubQuests.Count; i++)
        {
          SubQuestProgress progressSubQuest = new SubQuestProgress(quest.Value.SubQuests[i].Config.Type, 0, QuestState.UnAccepted);
          subQuests.Add(progressSubQuest);
        }

        Progress
          .Quests
          .Add(new QuestProgress(quest.Key, QuestState.UnAccepted, subQuests));
      }
    }
  }
}