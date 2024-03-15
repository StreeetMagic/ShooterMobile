using UnityEngine;

namespace Gameplay.Characters.Players.Animators
{
  public class PlayerAnimator : MonoBehaviour
  {
    private static readonly int IsRun = Animator.StringToHash(Run);

    private const string Run = "isRun";

    [SerializeField] private Animator _animator;

    public void PlayRunAnimation()
    {
      _animator.SetBool(IsRun, true);
    }

    public void Stop()
    {
      _animator.SetBool(IsRun, false);
    }

    public void Shoot()
    {
      _animator.SetBool("isShoot", true);
      Debug.Log("Shoot");
    }

    public void StopShoot()
    {
      _animator.SetBool("isShoot", false);
    }
  }
}