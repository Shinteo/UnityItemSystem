using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		Vector2 _scrollPos = Vector2.zero;

		int 
			_listViewWidth 			= 200,
			_listViewButtonwidth 	= 180,
			_listViewButtonHeight	= 25,

			_selectedIndex			= -1;
			



		void ListView()
		{
			_scrollPos = GUILayout.BeginScrollView (_scrollPos, "Box", GUILayout.ExpandHeight (true), GUILayout.Width(_listViewWidth));

			for (int cnt = 0; cnt < weaponDatabase.Count; cnt ++)
			{
				if(GUILayout.Button (weaponDatabase.Get(cnt).ItemName, "box", GUILayout.Width(_listViewButtonwidth), GUILayout.Height(_listViewButtonHeight)))
				{
					_selectedIndex = cnt;
					tempWeapon = weaponDatabase.Get(cnt);
					showNewWeaponDetails = true;
					state = DisplayState.DETAILS;
				}
			}

			GUILayout.EndScrollView();
		}
	}
}
