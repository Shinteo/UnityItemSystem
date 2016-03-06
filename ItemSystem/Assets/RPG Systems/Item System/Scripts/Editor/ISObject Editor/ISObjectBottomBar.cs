using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		void BottomBar()
		{
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			
			GUILayout.Label("Bottom Bar");
			
			GUILayout.EndHorizontal();
		}
	}
}
