using Gameplay.Upgrades;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;

namespace Infrastructure.DataRepositories
{
  public class EggsInBankStorage : IProgressWriter
  {
    public ReactiveProperty<int> EggsInBank { get; } = new();

    public void ReadProgress(Progress progress)
    {
      EggsInBank.Value = progress.EggsInBank;
    }

    public void WriteProgress(Progress progress)
    {
      progress.EggsInBank = EggsInBank.Value;
    }
  }
}