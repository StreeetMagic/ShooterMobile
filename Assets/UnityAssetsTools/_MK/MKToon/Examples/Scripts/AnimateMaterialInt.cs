//////////////////////////////////////////////////////
// MK Toon Examples Animate Material Int	     	//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

using UnityAssetsTools._MK.MKToon.Scripts;
using UnityEngine;

namespace UnityAssetsTools._MK.MKToon.Examples.Scripts
{
    public class AnimateMaterialInt : AnimateMaterialProperty<int>
    {
        public float scale = 1;
        public float offset = 0;

        public enum Property
        {
            LightBands
        };
        public Property property;

        public override void SetValue(Material material, int value)
        {
            switch(property)
            {
                case Property.LightBands:
                    Properties.lightBands.SetValue(material, value);
                break;
            }
        }

        public override int GenerateValue(Material material)
        {
            return Mathf.FloorToInt(scale * InterpValue() + offset);
        }
    }
}
