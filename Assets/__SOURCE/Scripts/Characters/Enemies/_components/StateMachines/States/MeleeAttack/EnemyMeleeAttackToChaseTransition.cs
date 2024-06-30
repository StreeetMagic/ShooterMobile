using Characters.Enemies._components.StateMachines.States.Chase;
using Characters.Enemies.Configs;
using Characters.FiniteStateMachines;
using Characters.Players;
using UnityEngine;

namespace Characters.Enemies._components.StateMachines.States.MeleeAttack
{
  public class EnemyMeleeAttackToChaseTransition : Transition
  {
    private readonly EnemyConfig _config;
    private readonly PlayerProvider _playerProvider;
    private readonly Transform _transform;
    
    public EnemyMeleeAttackToChaseTransition(EnemyConfig config, PlayerProvider playerProvider,
      Transform transform)
    {
      _config = config;
      _playerProvider = playerProvider;
      _transform = transform;
    }
    
    public override void Tick()
    {
      if (Vector3.Distance(_transform.position, _playerProvider.Instance.transform.position) < _config.MeleeRange)
        return;
      
      Enter<EnemyChaseState>();
    }
  }
}