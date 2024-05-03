using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;

namespace DataRepositories
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