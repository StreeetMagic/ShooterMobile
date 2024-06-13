using Infrastructure.PersistentProgresses;

namespace Infrastructure.SaveLoadServices
{
  public interface IProgressReader
  {
    void ReadProgress(ProjectProgress projectProgress);
  }
}