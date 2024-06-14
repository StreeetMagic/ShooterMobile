using System.Collections.Generic;
using Gameplay.Characters.Players;
using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using Gameplay.Stats;
using Gameplay.Upgrades;
using Infrastructure.ConfigServices;
using UnityEngine;

namespace Infrastructure.PersistentProgresses
{
  public class PersistentProgressService
  {
    private readonly ConfigService _configService;

    public PersistentProgressService(ConfigService configService)
    {
      _configService = configService;
    }

    public ProjectProgress ProjectProgress { get; private set; }

    public void LoadProgress(string getString) =>
      ProjectProgress =
        JsonUtility
          .FromJson<ProjectProgress>(getString);

    public void SetDefault()
    {
      DefaultProjectProgressConfig defaultProgress = _configService.DefaultProjectProgressConfig;
      
      PlayerConfig playerConfig = _configService.PlayerConfig;
      
      ProjectProgress = new ProjectProgress
      {
        MoneyInBank = defaultProgress.MoneyInBank,
        EggsInBank = defaultProgress.EggsInBank, 
        //PlayerPosition = defaultProgress.PlayerPosition, 
        Expierience = defaultProgress.Expierience, 
        MusicMute = defaultProgress.MusicMute, 
        PlayerWeaponId = playerConfig.StartWeapon,
      };

      Upgrades();
      Quests();
    }

    private void Upgrades()
    {
      ProjectProgress.Upgrades = new List<UpgradeProgress>();

      Dictionary<StatId, UpgradeConfig> upgrades =
        _configService
          .UpgradeConfigs;

      foreach (KeyValuePair<StatId, UpgradeConfig> upgrade in upgrades)
        ProjectProgress
          .Upgrades
          .Add(new UpgradeProgress(upgrade.Key, 0));
    }

    private void Quests()
    {
      ProjectProgress.Quests = new List<QuestProgress>();

      Dictionary<QuestId, QuestConfig> questConfigs =
        _configService
          .QuestConfigs;

      foreach (KeyValuePair<QuestId, QuestConfig> questConfig in questConfigs)
      {
        List<SubQuestProgress> subQuests = new List<SubQuestProgress>();

        for (var i = 0; i < questConfig.Value.SubQuests.Count; i++)
        {
          SubQuestProgress subQuestProgress = new(questConfig.Value.SubQuests[i].Id, 0, QuestState.UnActivated);
          subQuests.Add(subQuestProgress);
        }

        ProjectProgress
          .Quests
          .Add(new QuestProgress(questConfig.Key, QuestState.UnActivated, subQuests));
      }
    }
  }
}