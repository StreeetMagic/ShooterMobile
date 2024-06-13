using System;

namespace Infrastructure.RandomServices
{
  public class RandomService
  {
    public string GetRandomUniqueId() =>
      Guid
        .NewGuid()
        .ToString();
  }
}