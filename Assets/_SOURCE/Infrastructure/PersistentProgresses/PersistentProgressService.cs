using System;
using Infrastructure.Utilities;

namespace Infrastructure.PersistentProgresses
{
  public class PersistentProgressService
  {
    public Progress Progress { get; set; }
  }

  [Serializable]
  public class Progress
  {
  }
}