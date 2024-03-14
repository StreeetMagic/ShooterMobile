using System.Collections.Generic;
using Gameplay.Characters.Players.Shooters.Projectiles;
using UnityEngine;

public class ProjectileStorage
{
  private Dictionary<string, Projectile> _projectiles = new();

  public void Add(string guid, Projectile projectile)
  {
    _projectiles.Add(guid, projectile);
  }

  public void Remove(string guid)
  {
    if (!_projectiles.ContainsKey(guid))
    {
      Debug.LogError($"Projectile with guid {guid} not found");
      return;
    }

    _projectiles.Remove(guid);
  }

  public Projectile Get(string guid)
  {
    if (_projectiles.TryGetValue(guid, out Projectile projectile))
      return projectile;

    Debug.LogError($"Projectile with guid {guid} not found");
    return null;
  }
}