using System;
using System.Collections;
using System.Collections.Generic;
using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;

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
