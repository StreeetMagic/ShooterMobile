using System;

namespace RandomServices
{
  public class RandomService
  {
    public string GetRandomUniqueId() =>
      Guid
        .NewGuid()
        .ToString();
  }
}