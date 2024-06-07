using PersistentProgresses;
using SaveLoadServices;
using Utilities;

namespace Gameplay.CurrencyRepositories
{
  public class MoneyInBankStorage : IProgressWriter
  {
    public ReactiveProperty<int> MoneyInBank { get; } = new();

    public void ReadProgress(ProjectProgress projectProgress) =>
      MoneyInBank.Value = projectProgress.MoneyInBank;

    public void WriteProgress(ProjectProgress projectProgress) =>
      projectProgress.MoneyInBank = MoneyInBank.Value;
  }
}