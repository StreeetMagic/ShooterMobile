using _Infrastructure.Projects;

namespace _Infrastructure.SaveLoadServices
{
  public interface IProgressWriter : IProgressReader
  {
    void WriteProgress(ProjectProgress projectProgress);
  }
}