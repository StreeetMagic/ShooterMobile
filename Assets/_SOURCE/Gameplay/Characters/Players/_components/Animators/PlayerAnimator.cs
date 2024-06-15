using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Characters.Players.Animators
{
  public class PlayerAnimator : MonoBehaviour
  {
    public Animator Animator;
    
    private static readonly int s_isRun = Animator.StringToHash(Run);
    private static readonly int s_pistolShoot = Animator.StringToHash(PistolShoot);
    private static readonly int s_rifleShoot = Animator.StringToHash(RifleShoot);
    private static readonly int s_shotgunShoot = Animator.StringToHash(ShotgunShoot);
    private static readonly int s_granadeThrow = Animator.StringToHash(GrenadeThrow);
    private static readonly int s_reload = Animator.StringToHash(Reload);

    [Header("Knife hit animations")] public string KnifeHit1 = "KnifeHit1";
    public string KnifeHit2 = "KnifeHit2";
    public string KnifeHit3 = "KnifeHit3";

    private const string Run = "isRun";
    private const string PistolShoot = "PistolShoot";
    private const string RifleShoot = "RifleShoot";
    private const string ShotgunShoot = "ShotgunShoot";
    private const string GrenadeThrow = "GrenadeThrow";
    private const string Reload = "Reload";

    public void PlayRunAnimation()
    {
      Animator.SetBool(s_isRun, true);
    }

    public void Stop()
    {
      Animator.SetBool(s_isRun, false);
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

    public void PlayPistolShoot() => Animator.SetTrigger(s_pistolShoot);
    public void PlayRifleShoot() => Animator.SetTrigger(s_rifleShoot);
    public void PlayShotgunShoot() => Animator.SetTrigger(s_shotgunShoot);
    public void PlayGrenadeThrow() => Animator.SetTrigger(s_granadeThrow);
    public void PlayReload() => Animator.SetTrigger(s_reload);
  }
}