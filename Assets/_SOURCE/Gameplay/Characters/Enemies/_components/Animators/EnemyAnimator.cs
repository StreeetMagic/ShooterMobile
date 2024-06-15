using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies.Animators
{
  public class EnemyAnimator : MonoBehaviour
  {
    [SerializeField] private ParticleSystem _panicEffect;
    public const string Death1 = nameof(Death1);
    public const string Death2 = nameof(Death2);
    public const string Death3 = nameof(Death3);
    public const string Death4 = nameof(Death4);
    public const string IsRun = nameof(IsRun);
    public const string IsWalk = nameof(IsWalk);
    private const string GrenadeThrow = "GrenadeThrow";
    private const string Panic = "Panic";
    
    private static readonly int s_granadeThrow = Animator.StringToHash(GrenadeThrow);

    [Header("Knife hit animations")] 
    public string KnifeHit1 = "KnifeHit1";
    public string KnifeHit2 = "KnifeHit2";
    public string KnifeHit3 = "KnifeHit3";

    [Header("Shoot animations")]
    public const string Shoot = nameof(Shoot);
    public const string RifleShoot = nameof(RifleShoot);
    
    private readonly List<string> _deaths = new()
    {
      Death1,
      Death2,
      Death3,
      Death4
    };

    public Animator Animator;

    private static readonly int s_shoot = Animator.StringToHash(Shoot);
    private static readonly int s_rifleShoot = Animator.StringToHash(RifleShoot);
    private static readonly int s_isWalk = Animator.StringToHash(IsWalk);
    private static readonly int s_isRun = Animator.StringToHash(IsRun);
    private static readonly int s_panic = Animator.StringToHash(Panic);

    public event Action KnifeHit;

    public void PlayDeathAnimation()
    {
      Animator.SetTrigger(_deaths[Random.Range(0, _deaths.Count)]);
    }

    public void OnHit()
    {
      Debug.Log(" OnHit");
      KnifeHit?.Invoke();
    }

    [Button]
    public void PlayRandomKnifeHitAnimation(float duration)
    {
      string[] animations = new string[] { KnifeHit1, KnifeHit2, KnifeHit3 };
      int randomIndex = Random.Range(0, animations.Length);
      string selectedAnimation = animations[randomIndex];

      Animator.Play(selectedAnimation);

      AnimationClip animationClip = 
        Animator
          .runtimeAnimatorController
          .animationClips
          .FirstOrDefault(clip => clip.name == selectedAnimation);

      float animationLength = animationClip.length;
      Animator.speed = animationLength / duration;
    }
    
    public void PlayGrenadeThrow() => Animator.SetTrigger(s_granadeThrow);
    public void PlayPanic() => Animator.SetTrigger(s_panic);

    public void PlayRunAnimation()
    {
      Animator.SetBool(s_isWalk, false);
      Animator.SetBool(s_isRun, true);
    }

    public void PlayWalkAnimation()
    {
      Animator.SetBool(s_isRun, false);
      Animator.SetBool(s_isWalk, true);
    }

    public void StopRunAnimation()
    {
      Animator.SetBool(s_isRun, false);
    }

    public void StopWalkAnimation()
    {
      Animator.SetBool(s_isWalk, false);
    }

    public void PlayShootAnimation()
    {
      Animator.SetTrigger(s_shoot);
    }
    
    public void PlayRifleShootAnimation()
    {
      Animator.SetTrigger(s_rifleShoot);
    }

    private void PlayPanicEffect()
    {
      _panicEffect.Play();
    }
  }
}