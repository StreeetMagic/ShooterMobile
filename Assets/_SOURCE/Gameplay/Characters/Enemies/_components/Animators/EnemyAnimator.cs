using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
  public const string Death1 = nameof(Death1);
  public const string Death2 = nameof(Death2);
  public const string Death3 = nameof(Death3);
  public const string Death4 = nameof(Death4);
  public const string IsRun = nameof(IsRun);
  public const string IsWalk = nameof(IsWalk);

  private List<string> _deaths = new()
  {
    Death1,
    Death2,
    Death3,
    Death4
  };

  public Animator Animator;

  public void PlayDeathAnimation()
  {
    Animator.SetTrigger(_deaths[Random.Range(0, _deaths.Count)]);
  }

  public void PlayRunAnimation()
  {
    Animator.SetBool(IsWalk, false);
    Animator.SetBool(IsRun, true);
  }

  public void PlayWalkAnimation()
  {
    Animator.SetBool(IsRun, false);
    Animator.SetBool(IsWalk, true);
  }
}