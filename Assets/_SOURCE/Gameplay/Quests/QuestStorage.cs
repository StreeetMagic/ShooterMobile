using System.Collections.Generic;
using System.Linq;
using Configs.Resources.QuestConfigs.Scripts;
using Gameplay.RewardServices;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Quests.Subquests;

namespace Quests
{
  public class QuestStorage : IProgressWriter
  {
    private Dictionary<QuestId, Quest> _quests;

    private readonly IStaticDataService _staticDataService;
    private readonly SaveLoadService _saveLoadService;
    private readonly RewardService _rewardService;

    public QuestStorage(IStaticDataService staticDataService,
      SaveLoadService saveLoadService, RewardService rewardService)
    {
      _staticDataService = staticDataService;
      _saveLoadService = saveLoadService;
      _rewardService = rewardService;
    }

    public Quest GetQuest(QuestId questId)
      => _quests[questId];

    public List<Quest> GetAllQuests()
      => _quests.Values.ToList();

    public void ReadProgress(Progress progress)
    {
      Dictionary<QuestId, QuestConfig> configs = _staticDataService.GetQuestConfigs();

      _quests = new Dictionary<QuestId, Quest>();

      foreach (QuestId questId in configs.Keys)
      {
        List<SubQuest> subQuests = SubQuest(configs[questId], progress);

        QuestState questState = QuestState(progress, questId);

        _quests.Add(questId, new Quest(questState, configs[questId], subQuests, _rewardService));
      }
    }

    public void WriteProgress(Progress progress)
    {
      progress.Quests.Clear();

      foreach (KeyValuePair<QuestId, Quest> quest in _quests)
      {
        List<SubQuestProgress> subQuests = new List<SubQuestProgress>();

        foreach (SubQuest subQuest in quest.Value.SubQuests)
          subQuests.Add(new SubQuestProgress(subQuest.Setup.Config.Type, subQuest.CompletedQuantity.Value, subQuest.State.Value));

        progress.Quests.Add(new QuestProgress(quest.Key, quest.Value.State.Value, subQuests));
      }
    }

    private static QuestState QuestState(Progress progress, QuestId questId)
    {
      return progress
        .Quests
        .Find(x => x.Id == questId)
        .State;
    }

    private List<SubQuest> SubQuest(QuestConfig config, Progress progress)
    {
      List<SubQuest> subQuests = new List<SubQuest>();

      for (var i = 0; i < config.SubQuests.Count; i++)
      {
        SubQuestProgress progressSubQuest = progress.Quests.Find(x => x.Id == config.Id).SubQuests[i];

        SubQuestSetup setup = config.SubQuests[i];
        subQuests.Add(new SubQuest(setup, progressSubQuest.CompletedQuantity, progressSubQuest.State, i, _saveLoadService, _rewardService));
      }

      return subQuests;
    }
  }
}