using Infrastructure.PersistentProgresses;

namespace Infrastructure.SaveLoadServices
{
  public interface IProgressWriter : IProgressReader
  {
    void WriteProgress(ProjectProgress projectProgress);
  }
}