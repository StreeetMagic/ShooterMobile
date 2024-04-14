using System.Collections.Generic;
using System.Linq;
using Configs.Resources.QuestConfigs;
using DataRepositories.Quests;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Quests;

public class QuestStorage : IProgressWriter
{
  private readonly IStaticDataService _staticDataService;

  private Dictionary<QuestId, Quest> _quests;

  public QuestStorage(IStaticDataService staticDataService)
  {
    _staticDataService = staticDataService;
  }

  public void ReadProgress(Progress progress)
  {
    Dictionary<QuestId, QuestConfig> configs = _staticDataService.GetQuestConfigs();

    _quests = new Dictionary<QuestId, Quest>();

    foreach (QuestId questId in configs.Keys)
    {
      List<SubQuest> subQuests = SubQuest(configs[questId], progress);
      _quests.Add(questId, new Quest(QuestState(progress, questId), configs[questId], subQuests));
    }
  }

  private static QuestState QuestState(Progress progress, QuestId questId)
  {
    return progress
      .Quests
      .Find(x => x.Id == questId)
      .State;
  }

  private static List<SubQuest> SubQuest(QuestConfig config, Progress progress)
  {
    List<SubQuest> subQuests = new List<SubQuest>();

    for (var i = 0; i < config.SubQuests.Count; i++)
    {
      SubQuestProgress progressSubQuest = progress.Quests.Find(x => x.Id == config.Id).SubQuests[i];

      SubQuestSetup setup = config.SubQuests[i];
      subQuests.Add(new SubQuest(setup.Config, setup.Quantity, progressSubQuest.State));
    }

    return subQuests;
  }

  public void WriteProgress(Progress progress)
  {
    progress.Quests.Clear();

    foreach (KeyValuePair<QuestId, Quest> quest in _quests)
    {
      List<SubQuestProgress> subQuests = new List<SubQuestProgress>();

      foreach (SubQuest subQuest in quest.Value.SubQuests)
        subQuests.Add(new SubQuestProgress(subQuest.Config.Type, subQuest.CompletedQuantity, subQuest.State));

      progress.Quests.Add(new QuestProgress(quest.Key, quest.Value.State, subQuests));
    }
  }
}