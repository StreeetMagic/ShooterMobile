using _Infrastructure.Projects;

namespace _Infrastructure.SaveLoadServices
{
  public interface IProgressReader
  {
    void ReadProgress(ProjectProgress projectProgress);
  }
}