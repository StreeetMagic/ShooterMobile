//////////////////////////////////////////////////////
// MK Toon Examples AnimateMaterialFloat        	//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

using UnityAssetsTools._MK.MKToon.Scripts;
using UnityEngine;

namespace UnityAssetsTools._MK.MKToon.Examples.Scripts
{
    public class AnimateMaterialFloat : AnimateMaterialProperty<float>
    {
        public float scale = 1;
        public float offset = 0;

        public enum Property
        {
            Smoothness,
            Metallic,
            DissolveAmount,
            NormalMapIntensity,
            OcclusionMapIntensity,
            Parallax,
            DetailMix,
            DetailAdditive,
            DetailMultiplicative,
            DetailNormalMapIntensity,
            DiffuseSmoothness,
            SpecularSmoothness,
            RimSmoothness,
            IridescenceSmoothness,
            LightTransmissionSmoothness,
            GoochRampIntensity,
            IridescenceSize,
            ColorGradingBrightness,
            ColorGradingSaturation,
            ColorGradingContrast,
            Anisotropy
        };
        public Property property;

        public override void SetValue(Material material, float value)
        {
            switch(property)
            {
                case Property.Smoothness:
                    Properties.smoothness.SetValue(material, value);
                break;
                case Property.Metallic:
                    Properties.metallic.SetValue(material, value);
                break;
                case Property.DissolveAmount:
                    Properties.dissolveAmount.SetValue(material, value);
                break;
                case Property.NormalMapIntensity:
                    Properties.normalMapIntensity.SetValue(material, value);
                break;
                case Property.OcclusionMapIntensity:
                    Properties.occlusionMapIntensity.SetValue(material, value);
                break;
                case Property.Parallax:
                    Properties.parallax.SetValue(material, value);
                break;
                case Property.DetailMix:
                case Property.DetailMultiplicative:
                case Property.DetailAdditive:
                    Properties.detailMix.SetValue(material, value);
                break;
                case Property.DetailNormalMapIntensity:
                    Properties.detailNormalMapIntensity.SetValue(material, value);
                break;
                case Property.DiffuseSmoothness:
                    Properties.diffuseSmoothness.SetValue(material, value);
                break;
                case Property.SpecularSmoothness:
                    Properties.specularSmoothness.SetValue(material, value);
                break;
                case Property.RimSmoothness:
                    Properties.rimSmoothness.SetValue(material, value);
                break;
                case Property.IridescenceSmoothness:
                    Properties.iridescenceSmoothness.SetValue(material, value);
                break;
                case Property.LightTransmissionSmoothness:
                    Properties.lightTransmissionSmoothness.SetValue(material, value);
                break;
                case Property.GoochRampIntensity:
                    Properties.goochRampIntensity.SetValue(material, value);
                break;
                case Property.IridescenceSize:
                    Properties.iridescenceSize.SetValue(material, value);
                break;
                case Property.ColorGradingContrast:
                    Properties.contrast.SetValue(material, value);
                break;
                case Property.ColorGradingSaturation:
                    Properties.saturation.SetValue(material, value);
                break;
                case Property.ColorGradingBrightness:
                    Properties.brightness.SetValue(material, value);
                break;
                case Property.Anisotropy:
                    Properties.anisotropy.SetValue(material, value);
                break;
            }
        }

        public override float GenerateValue(Material material)
        {
            return scale * InterpValue() + offset;
        }
    }
}
