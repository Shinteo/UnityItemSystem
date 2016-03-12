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


		Vector2 buttonSize = new Vector2 (180, 25);
			



		//Main code to display the list of items we have inside the database in the list view
		void ListView()
		{
			//If something is selected, hide the list panel
			if (state != DisplayState.NONE)
				//return;
				//If you'd rather just grey out the panel, then uncomment the below two GUI.enable control, and comment out the above return
				GUI.enabled = false;

			//If nothing is selected, show the list panel

			//To create a scroll bar
			_scrollPos = GUILayout.BeginScrollView (_scrollPos, "Box", GUILayout.ExpandHeight (true), GUILayout.Width(_listViewWidth));

			//The actual list itself
			for (int cnt = 0; cnt < weaponDatabase.Count; cnt ++)
			{
				if(GUILayout.Button (weaponDatabase.Get(cnt).ItemName, "box", GUILayout.Width(_listViewButtonwidth), GUILayout.Height(_listViewButtonHeight)))
				{
					_selectedIndex = cnt;
					tempWeapon = new ISWeapon (weaponDatabase.Get(cnt));
					showNewWeaponDetails = true;
					state = DisplayState.DETAILS;
				}
			}

			GUI.enabled = true;

			GUILayout.EndScrollView();
		}
	}
}
