using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Players.Animators
{
  public class PlayerAnimator : MonoBehaviour
  {
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
    private const string WeaponUp = "WeaponUp";
    private const string StartShooting = "StartShooting";
    public const string Death1 = nameof(Death1);
    public const string Death2 = nameof(Death2);
    public const string Death3 = nameof(Death3);
    public const string Death4 = nameof(Death4);

    public Animator Animator;
    private static readonly int s_isShoot = Animator.StringToHash("isShoot");
    private static readonly int s_startShooting = Animator.StringToHash(StartShooting);
    private static readonly int s_weaponUp = Animator.StringToHash(WeaponUp);

    private readonly List<string> _deaths = new()
    {
      Death1,
      Death2,
      Death3,
      Death4
    };

    public void PlayRunAnimation()
    {
      Animator.SetBool(s_isRun, true);
    }

    public void Stop()
    {
      Animator.SetBool(s_isRun, false);
    }
    
    public event Action KnifeHit;

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

      if (animationClip == null)
        return;

      float animationLength = animationClip.length;
      Animator.speed = animationLength / duration;
    }

    public void PlayPistolShoot() => Animator.SetTrigger(s_pistolShoot);
    public void PlayRifleShoot() => Animator.SetTrigger(s_rifleShoot);
    public void PlayShotgunShoot() => Animator.SetTrigger(s_shotgunShoot);
    public void PlayGrenadeThrow() => Animator.SetTrigger(s_granadeThrow);
    public void PlayReload() => Animator.SetTrigger(s_reload);

    public void PlayDeathAnimation()
    {
      Animator.SetTrigger(_deaths[Random.Range(0, _deaths.Count)]);
    }

    public void StopShoot()
    {
      Animator.SetBool(s_isShoot, false);
    }

    public void OnStateShooting()
    {
      Animator.SetBool(s_startShooting, true);
    }

    public void OffStateShooting()
    {
      SetWeaponDown();
      Animator.SetBool(s_startShooting, false);
    }

    private void ReloadFinished()
    {
    }

    private void GrenadeThrew()
    {
    }

    private void SetWeaponUp()
    {
      Animator.SetBool(s_weaponUp, true);
    }

    private void SetWeaponDown()
    {
      Animator.SetBool(s_weaponUp, false);
    }
    
    public void OnHit()
    {
      KnifeHit?.Invoke();
    }
  }
}