using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Characters.Pets.Hens
{
  public class HenSpawner
  {
    private readonly List<Hen> _hens = new List<Hen>();

    private readonly HenFactory _henFactory;

    public HenSpawner(HenFactory henFactory)
    {
      _henFactory = henFactory;
    }

    public void Spawn()
    {
      _hens.Add(_henFactory.Create());
    }

    public void DeSpawnAll()
    {
      foreach (Hen hen in _hens)
      {
        Object.Destroy(hen.gameObject);
      }

      _hens.Clear();
    }
  }
}