using Gameplay.Characters.FiniteStateMachines;
using Infrastructure.ConfigServices;

namespace Gameplay.Characters.Enemies.StateMachines.States.Idle
{
  public class EnemyIdleToPatrolTransition : Transition
  {
    private ConfigProvider _configProvider;

    public EnemyIdleToPatrolTransition(ConfigProvider configProvider)
    {
      _configProvider = configProvider;
    }

    public override void Tick()
    {
    }
  }
}