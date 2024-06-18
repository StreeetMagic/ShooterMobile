using System;

namespace Infrastructure.RandomServices
{
  public class RandomService
  {
    private static Random _random = new Random();

    public int GetRandomInt(int min, int max) =>
      _random.Next(min, max);

    public float GetRandomFloat(float max) =>
      (float)_random.NextDouble() * max;

    public string GetRandomUniqueId() =>
      Guid
        .NewGuid()
        .ToString();
  }
}