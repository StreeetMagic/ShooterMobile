using BaseTriggers;
using UnityEngine;

namespace Characters.Sellers
{
    public class SellerAnimator : MonoBehaviour
    {
        [SerializeField] private BaseTrigger _baseTrigger;
        [SerializeField] private Animator _animator;

        private string _isTalkAnimation = "IsTalk";

        public void PlayTalkAnimation()
        {
            _animator.SetBool(_isTalkAnimation, true);
        }

        public void StopTalkAnimation()
        {
            _animator.SetBool(_isTalkAnimation, false);
        }
    }
}
