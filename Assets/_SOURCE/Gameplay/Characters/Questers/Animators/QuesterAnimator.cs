using UnityEngine;

namespace Gameplay.Characters.NPC
{
    public class QuesterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int Talk = Animator.StringToHash(IsTalk);

        private const string IsTalk = nameof(IsTalk);

        public void PlayTalkAnimation()
        {
            _animator.SetBool(Talk, true);
        }

        public void StopTalkAnimation()
        {
            _animator.SetBool(Talk, false);
        }
    }
}
