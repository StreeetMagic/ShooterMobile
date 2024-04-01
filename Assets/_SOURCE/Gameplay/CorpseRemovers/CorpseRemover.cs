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
    public List<EnemyHealth> Enemies { get; } = new();

    private readonly ICoroutineRunner _coroutineRunner;
    private readonly List<CoroutineDecorator> _coroutines = new();

    public CorpseRemover(ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public void Add(EnemyHealth enemyHealth)
    {
      Enemies.Add(enemyHealth);
      enemyHealth.Died += OnDied;
    }

    public void Dispose()
    {
      _coroutines.Clear();
    }

    private void OnDied(EnemyConfig config, EnemyHealth enemyHealth)
    {
      enemyHealth.Died -= OnDied;

      var coroutineDecorator = new CoroutineDecorator(_coroutineRunner, () => RemoveCorpse(enemyHealth));
      coroutineDecorator.Start();

      _coroutines.Add(coroutineDecorator);
    }

    private IEnumerator RemoveCorpse(EnemyHealth enemyHealth)
    {
      yield return new WaitForSeconds(2f);

      if (enemyHealth == null)
        yield break;

      if (enemyHealth.transform == null)
        yield break;

      Object.Destroy(enemyHealth.transform.gameObject);
    }
  }
}