using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		Vector2 _scrollPos = Vector2.zero;
		int _listViewWidth = 200;



		void ListView()
		{
			_scrollPos = GUILayout.BeginScrollView (_scrollPos, "Box", GUILayout.ExpandHeight (true), GUILayout.Width(_listViewWidth));

			GUILayout.Label("Object List");

			GUILayout.EndScrollView();
		}
	}
}
