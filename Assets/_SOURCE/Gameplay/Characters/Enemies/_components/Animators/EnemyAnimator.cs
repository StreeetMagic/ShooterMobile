using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Animators
{
    public class EnemyAnimator : MonoBehaviour
    {
        public const string Death1 = nameof(Death1);
        public const string Death2 = nameof(Death2);
        public const string Death3 = nameof(Death3);
        public const string Death4 = nameof(Death4);
        public const string IsRun = nameof(IsRun);
        public const string IsWalk = nameof(IsWalk);
        public const string Shoot = nameof(Shoot);

        private readonly List<string> _deaths = new()
        {
            Death1,
            Death2,
            Death3,
            Death4
        };

        public Animator Animator;
        
        private static readonly int s_shoot = Animator.StringToHash(Shoot);
        private static readonly int s_isWalk = Animator.StringToHash(IsWalk);
        private static readonly int s_isRun = Animator.StringToHash(IsRun);

        public void PlayDeathAnimation()
        {
            Animator.SetTrigger(_deaths[Random.Range(0, _deaths.Count)]);
        }

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
    }
}