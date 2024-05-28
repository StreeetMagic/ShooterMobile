using System;

namespace _Infrastructure.RandomServices
{
  public class RandomService
  {
    public string GetRandomUniqueId() =>
      Guid
        .NewGuid()
        .ToString();
  }
}