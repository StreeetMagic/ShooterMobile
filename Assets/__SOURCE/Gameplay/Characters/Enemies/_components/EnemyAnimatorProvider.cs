using Gameplay.Characters.Enemies.Animators;

namespace Gameplay.Characters.Enemies
{
  public class EnemyAnimatorProvider
  {
    private EnemyAnimator _instance;

    public EnemyAnimator Instance
    {
      get
      {
        if (!_instance)
           throw new System.NullReferenceException(); 
        
        return _instance;
      }
      
      set => _instance = value;
    }
  }
}