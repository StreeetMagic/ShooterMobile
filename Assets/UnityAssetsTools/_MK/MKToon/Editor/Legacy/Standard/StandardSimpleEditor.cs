//////////////////////////////////////////////////////
// MK Toon Built-in  Standard Simple Editor        	//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2021 All rights reserved.            //
//////////////////////////////////////////////////////

#if UNITY_EDITOR
using UnityAssetsTools._MK.MKToon.Editor.Base;
using UnityEditor;

namespace UnityAssetsTools._MK.MKToon.Editor.Legacy.Standard
{
    internal class StandardSimpleEditor : SimpleEditorBase 
    {
        protected override void DrawReceiveShadows(MaterialEditor materialEditor) {}
    }
}
#endif