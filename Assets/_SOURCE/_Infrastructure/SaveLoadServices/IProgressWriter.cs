using Projects;

namespace SaveLoadServices
{
  public interface IProgressWriter : IProgressReader
  {
    void WriteProgress(ProjectProgress projectProgress);
  }
}