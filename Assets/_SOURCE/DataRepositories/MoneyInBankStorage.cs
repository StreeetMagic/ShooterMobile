using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;

namespace DataRepositories
{
  public class MoneyInBankStorage : IProgressWriter
  {
    public ReactiveProperty<int> MoneyInBank { get; } = new();

    public void ReadProgress(Progress progress) =>
      MoneyInBank.Value = progress.MoneyInBank;

    public void WriteProgress(Progress progress) =>
      progress.MoneyInBank = MoneyInBank.Value;
  }
}