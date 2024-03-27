using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Gameplay.CorpseRemovers
{
  public class CorpseRemover : IDisposable
  {
    public List<Health> Enemies { get; } = new();

    private readonly ICoroutineRunner _coroutineRunner;
    private readonly List<CoroutineDecorator> _coroutines = new();

    public CorpseRemover(ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public void Add(Health health)
    {
      Enemies.Add(health);
      health.Died += OnDied;
    }

    public void Dispose()
    {
      foreach (CoroutineDecorator coroutineDecorator in _coroutines)
      {
        if (coroutineDecorator == null)
          continue;

        coroutineDecorator.Stop();
      }
    }

    private void OnDied(EnemyConfig config, Health health)
    {
      health.Died -= OnDied;

      var coroutineDecorator = new CoroutineDecorator(_coroutineRunner, () => RemoveCorpse(health));
      coroutineDecorator.Start();

      _coroutines.Add(coroutineDecorator);
    }

    private IEnumerator RemoveCorpse(Health health)
    {
      yield return new WaitForSeconds(2f);

      Object.Destroy(health.transform.parent.gameObject);
    }
  }
}