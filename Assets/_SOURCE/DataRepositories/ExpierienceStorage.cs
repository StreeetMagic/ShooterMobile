using Gameplay.Upgrades;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;

namespace Infrastructure.DataRepositories
{
  public class ExpierienceStorage : IProgressWriter
  {
    public ReactiveProperty<int> Expierience { get; } = new();

    public void ReadProgress(Progress progress)
    {
      Expierience.Value = progress.Expierience;
    }

    public void WriteProgress(Progress progress)
    {
      progress.Expierience = Expierience.Value;
    }
  }
}