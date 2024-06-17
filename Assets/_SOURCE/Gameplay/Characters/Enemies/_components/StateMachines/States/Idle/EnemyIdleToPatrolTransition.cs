using Gameplay.Characters.FiniteStateMachines;
using Infrastructure.ConfigServices;

namespace Gameplay.Characters.Enemies.StateMachines.States.Idle
{
  public class EnemyIdleToPatrolTransition : Transition
  {
    private ConfigService _configService;

    public EnemyIdleToPatrolTransition(ConfigService configService)
    {
      _configService = configService;
    }

    public override void Tick()
    {
    }
  }
}