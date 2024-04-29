using UnityEngine;

namespace Gameplay.Characters.Players.Animators
{
  public class PlayerAnimator : MonoBehaviour
  {
    private static readonly int s_isRun = Animator.StringToHash(Run);

    private const string Run = "isRun";

    [SerializeField] private Animator _animator;
    private static readonly int s_isShoot = Animator.StringToHash("isShoot");

    public void PlayRunAnimation()
    {
      _animator.SetBool(s_isRun, true);
    }

    public void Stop()
    {
      _animator.SetBool(s_isRun, false);
    }

    public void Shoot()
    {
      _animator.SetBool(s_isShoot, true);
    }

    public void StopShoot()
    {
      _animator.SetBool(s_isShoot, false);
    }
  }
}