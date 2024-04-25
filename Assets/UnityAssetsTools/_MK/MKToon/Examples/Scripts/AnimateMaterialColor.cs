//////////////////////////////////////////////////////
// MK Toon Examples AnimateMaterialColor            //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

using UnityAssetsTools._MK.MKToon.Scripts;
using UnityEngine;

namespace UnityAssetsTools._MK.MKToon.Examples.Scripts
{
    public class AnimateMaterialColor : AnimateMaterialProperty<Color>
    {
        public float intensity = 1f;
        public Color color0 = Color.white, color1 = Color.grey;
        
        public enum Property
        {
            EmissionColor,
            GoochBrightColor,
            GoochDarkColor,
            RimColor,
            RimBrightColor,
            RimDarkColor
        };
        public Property property;

        public override void SetValue(Material material, Color value)
        {
            switch(property)
            {
                case Property.EmissionColor:
                    Properties.emissionColor.SetValue(material, value * intensity);
                break;
                case Property.GoochBrightColor:
                    Properties.goochBrightColor.SetValue(material, value * intensity);
                break;
                case Property.GoochDarkColor:
                    Properties.goochDarkColor.SetValue(material, value * intensity);
                break;
                case Property.RimColor:
                    Properties.rimColor.SetValue(material, value * intensity);
                break;
                case Property.RimBrightColor:
                    Properties.rimBrightColor.SetValue(material, value * intensity);
                break;
                case Property.RimDarkColor:
                    Properties.rimDarkColor.SetValue(material, value * intensity);
                break;
            }
        }

        public override Color GenerateValue(Material material)
        {
            return Color.Lerp(color0, color1, InterpValue());
        }
    }
}
