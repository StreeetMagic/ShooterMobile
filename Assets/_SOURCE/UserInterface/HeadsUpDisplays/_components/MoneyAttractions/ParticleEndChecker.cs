using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.MoneyAttractions
{
    public class ParticleEndChecker : MonoBehaviour
    {
        [SerializeField] private ParticleImage _particleImage;

        private void OnEnable()
        {
            _particleImage.onParticleFinish.AddListener(test);
        }

        void test()
        {
            print("партикл");
        
        }
    }
}
