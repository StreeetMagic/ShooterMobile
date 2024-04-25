//////////////////////////////////////////////////////
// MK Toon Examples UpdateRotationSlider            //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

using UnityEngine;

namespace UnityAssetsTools._MK.MKToon.Examples.Scripts
{
    public class UpdateRotationSlider : MonoBehaviour
    {
        [SerializeField]
        private UnityEngine.UI.Slider _slider = null;
        [SerializeField]
        private SpectateCamera _spectateCamera = null;

        private void Update()
        {
            if(_spectateCamera)
                _slider.value = _spectateCamera.time;
        }
    }
}
