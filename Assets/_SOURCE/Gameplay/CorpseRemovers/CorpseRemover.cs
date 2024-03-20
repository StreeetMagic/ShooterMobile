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
      
    }

    private void OnDied(EnemyConfig config, Health health)
    {
      health.Died -= OnDied;

      new CoroutineDecorator(_coroutineRunner, () => RemoveCorpse(health))
        .Start();
    }

    private IEnumerator RemoveCorpse(Health health)
    {
      yield return new WaitForSeconds(2f);

      Object.Destroy(health.transform.parent.gameObject);
    }
  }
}