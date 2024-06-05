using System.Collections;
using System.Collections.Generic;
using CoroutineRunners;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Gameplay.CorpseRemovers
{
  public class CorpseRemover
  {
    public List<IHealth> Enemies { get; } = new();

    private readonly ICoroutineRunner _coroutineRunner;

    public CorpseRemover(ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public void Add(IHealth enemyHealth)
    {
      Enemies.Add(enemyHealth);
      enemyHealth.Died += OnDied;
    }

    private void OnDied(EnemyConfig config, IHealth enemyHealth)
    {
      enemyHealth.Died -= OnDied;

      var coroutineDecorator = new CoroutineDecorator(_coroutineRunner, () => RemoveCorpse(enemyHealth));
      coroutineDecorator.Start();
    }

    private IEnumerator RemoveCorpse(IHealth enemyHealth)
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