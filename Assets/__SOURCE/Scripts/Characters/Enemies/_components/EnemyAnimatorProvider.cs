using Characters.Enemies._components.Animators;

namespace Characters.Enemies._components
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