using PersistentProgresses;
using SaveLoadServices;
using Utilities;

namespace Gameplay.CurrencyRepositories
{
  public class EggsInBankStorage : IProgressWriter
  {
    public ReactiveProperty<int> EggsInBank { get; } = new();

    public void ReadProgress(ProjectProgress projectProgress)
    {
      EggsInBank.Value = projectProgress.EggsInBank;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.EggsInBank = EggsInBank.Value;
    }
  }
}