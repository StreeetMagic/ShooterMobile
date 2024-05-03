using System;

namespace Infrastructure
{
  public class RandomService
  {
    public string GetRandomUniqueId() =>
      Guid
        .NewGuid()
        .ToString();
  }
}