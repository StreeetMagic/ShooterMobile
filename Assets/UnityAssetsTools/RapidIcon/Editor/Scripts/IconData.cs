using System;
using System.Collections.Generic;

namespace UnityAssetsTools.RapidIcon.Editor.Scripts
{
	[Serializable]
	public class IconData
	{
		public List<Icon> icons;

		public IconData()
		{
			icons = new List<Icon>();
		}
	}
}