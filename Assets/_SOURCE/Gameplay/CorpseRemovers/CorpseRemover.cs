using System.Collections;
using System.Collections.Generic;
using _Infrastructure.CoroutineRunners;
using _Infrastructure.Utilities;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Gameplay.CorpseRemovers
{
  public class CorpseRemover
  {
    public List<EnemyHealth> Enemies { get; } = new();

    private readonly ICoroutineRunner _coroutineRunner;

    public CorpseRemover(ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public void Add(EnemyHealth enemyHealth)
    {
      Enemies.Add(enemyHealth);
      enemyHealth.Died += OnDied;
    }

    private void OnDied(EnemyConfig config, EnemyHealth enemyHealth)
    {
      enemyHealth.Died -= OnDied;

      var coroutineDecorator = new CoroutineDecorator(_coroutineRunner, () => RemoveCorpse(enemyHealth));
      coroutineDecorator.Start();
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