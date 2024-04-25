﻿//////////////////////////////////////////////////////
// MK Toon Uniform                  	    	   	//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2021 All rights reserved.            //
//////////////////////////////////////////////////////

namespace UnityAssetsTools._MK.MKToon.Scripts
{
    public class Uniform
    {
        protected string _name;
        public string name
        {
            get{ return _name; }
        }
        protected int _id;
        public int id
        {
            get{ return _id; }
        }
        public Uniform(string name)
        {
            _name = name;
            _id = UnityEngine.Shader.PropertyToID(name);
        }
    }
}
