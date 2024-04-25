//////////////////////////////////////////////////////
// MK Toon Particles Simple Editor        			//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2021 All rights reserved.            //
//////////////////////////////////////////////////////

#if UNITY_EDITOR
using UnityAssetsTools._MK.MKToon.Editor.Base;
using UnityEditor;

namespace UnityAssetsTools._MK.MKToon.Editor.Legacy.Particles
{
    internal sealed class ParticlesSimpleEditor : SimpleEditorBase
    {
        protected override void DrawReceiveShadows(MaterialEditor materialEditor) {}
    }
}
#endif