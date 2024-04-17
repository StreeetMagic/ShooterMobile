using System.Collections.Generic;
using Configs.Resources.ExpirienceConfigs;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;

namespace Infrastructure.DataRepositories
{
  public class ExpierienceStorage : IProgressWriter
  {
    private readonly IStaticDataService _staticDataService;

    public ExpierienceStorage(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public ReactiveProperty<int> AllPoints { get; } = new();

    public int CurrentLevel
    {
      get
      {
        List<ExpirienceSetup> setups = Config.Levels;

        int currentLevel = 1;
        int expirienceLeft = AllPoints.Value;

        while (expirienceLeft >= setups[currentLevel].Expierience)
        {
          expirienceLeft -= setups[currentLevel].Expierience;
          currentLevel++;
        }

        return currentLevel;
      }
    }

    public int CurrentExpierience
    {
      get
      {
        List<ExpirienceSetup> setups = Config.Levels;

        int currentLevel = 1;
        int expirienceLeft = AllPoints.Value;

        while (expirienceLeft >= setups[currentLevel].Expierience)
        {
          expirienceLeft -= setups[currentLevel].Expierience;
          currentLevel++;
        }

        return expirienceLeft;
      }
    }
    
    public int ExpierienceToNextLevel
    {
      get
      {
        List<ExpirienceSetup> setups = Config.Levels;

        int currentLevel = 1;
        int expirienceLeft = AllPoints.Value;

        while (expirienceLeft >= setups[currentLevel].Expierience)
        {
          expirienceLeft -= setups[currentLevel].Expierience;
          currentLevel++;
        }

        return setups[currentLevel].Expierience;
      }
    }

    private ExpirienceConfig Config => _staticDataService.GetExpirienceConfig();

    public void ReadProgress(Progress progress)
    {
      AllPoints.Value = progress.Expierience;
    }

    public void WriteProgress(Progress progress)
    {
      progress.Expierience = AllPoints.Value;
    }
  }
}