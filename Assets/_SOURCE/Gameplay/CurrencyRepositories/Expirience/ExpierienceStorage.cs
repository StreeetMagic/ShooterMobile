using System.Collections.Generic;
using Infrastructure.ConfigServices;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;

namespace Gameplay.CurrencyRepositories.Expirience
{
  public class ExpierienceStorage : IProgressWriter
  {
    private readonly ConfigService _configService;

    public ExpierienceStorage(ConfigService configService)
    {
      _configService = configService;
    }

    public ReactiveProperty<int> AllPoints { get; } = new();

    private ExpirienceConfig Config => _configService.ExpirienceConfig;

    public void ReadProgress(ProjectProgress projectProgress)
    {
      AllPoints.Value = projectProgress.Expierience;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.Expierience = AllPoints.Value;
    }

    public int CurrentLevel()
    {
      CalculateLevelAndExperience(out int currentLevel, out _);
      return currentLevel;
    }

    public int CurrentExpierience()
    {
      CalculateLevelAndExperience(out _, out int expirienceLeft);
      return expirienceLeft;
    }

    public int ExpierienceToNextLevel()
    {
      CalculateLevelAndExperience(out int currentLevel, out int _);
      List<ExpirienceSetup> setups = Config.Levels;
      return setups[currentLevel].Expierience;
    }

    private void CalculateLevelAndExperience(out int currentLevel, out int expirienceLeft)
    {
      List<ExpirienceSetup> setups = Config.Levels;

      currentLevel = 1;
      expirienceLeft = AllPoints.Value;

      while (expirienceLeft >= setups[currentLevel].Expierience)
      {
        expirienceLeft -= setups[currentLevel].Expierience;
        currentLevel++;
      }
    }
  }
}