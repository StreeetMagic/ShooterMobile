using System.Collections.Generic;
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
    {
      QuestConfig config = configs[questId];
    }
  }

  public void WriteProgress(Progress progress)
  {
    throw new System.NotImplementedException();
  }
}