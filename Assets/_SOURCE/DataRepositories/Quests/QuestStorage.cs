using System.Collections.Generic;
using System.Linq;
using Configs.Resources.QuestConfigs;
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
      _quests.Add(questId, new Quest(QuestState(progress, questId), configs[questId]));
  }

  private static QuestState QuestState(Progress progress, QuestId questId)
  {
    return progress
      .Quests
      .Find(x => x.Id == questId)
      .State;
  }

  public void WriteProgress(Progress progress)
  {
    progress.Quests.Clear();

    foreach (KeyValuePair<QuestId, Quest> quest in _quests)
      progress.Quests.Add(new QuestProgress(quest.Key, quest.Value.State));
  }
}