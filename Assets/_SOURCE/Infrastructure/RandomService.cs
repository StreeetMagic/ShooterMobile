using System;

namespace Gameplay.Characters.Enemies.Spawners
{
  public class RandomService
  {
    public string GetRandomUniqueId() =>
      Guid
        .NewGuid()
        .ToString();
  }
}