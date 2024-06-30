using System;

namespace Infrastructure.RandomServices
{
  public class RandomService
  {
    private static readonly Random s_random = new Random();

    public int GetRandomInt(int min, int max) =>
      s_random.Next(min, max);

    public float GetRandomFloat(float max) =>
      (float)s_random.NextDouble() * max;

    public string GetRandomUniqueId() =>
      Guid
        .NewGuid()
        .ToString();
  }
}