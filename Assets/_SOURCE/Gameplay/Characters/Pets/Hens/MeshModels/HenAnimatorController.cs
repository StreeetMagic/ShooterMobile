using UnityEngine;

namespace Gameplay.Characters.Pets.Hens.MeshModels
{
    public class HenAnimatorController : MonoBehaviour
    {
        [SerializeField] private float _delayToBoom;
        [SerializeField] private float _delayToFollowTarget;
        [SerializeField] private Animator _animator;
    
        private const string IsMove = nameof(IsMove);
        private const string IsFastSpeed = nameof(IsFastSpeed);
        private const string Alarm = nameof(Alarm);
        private const string Boom = nameof(Boom);

        public void PlayWalkAnimation()
        {
            _animator.SetBool(IsMove, true);
        }

        public void StopMovingAnimation()
        {
            _animator.SetBool(IsMove, false);
            _animator.SetBool(IsFastSpeed, false);
        }

        public void PlayFastRunAnimation()
        {
            _animator.SetBool(IsFastSpeed, true);
        }

        public float PlayAlarmAnimation()
        {
            _animator.SetTrigger(Alarm);
            return _delayToFollowTarget;
        }

        public float PlayBoomAnimation()
        {
            _animator.SetTrigger(Boom);
            return _delayToBoom;
        }
    }
}
