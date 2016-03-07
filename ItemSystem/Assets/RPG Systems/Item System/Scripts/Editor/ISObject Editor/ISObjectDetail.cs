using UnityEngine;
using UnityEditor;
using System.Collections;

namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		enum DisplayState
		{
			NONE,
			DETAILS
		}



		ISWeapon tempWeapon = new ISWeapon();
		bool showNewWeaponDetails = false;



		DisplayState state = DisplayState.NONE;



		void ItemDetails()
		{
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			GUILayout.BeginVertical(GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true));

			EditorGUILayout.LabelField ("State: " +state);
			switch (state)
			{
			case DisplayState.DETAILS:
				if (showNewWeaponDetails)
					DisplayNewWeapon();
				break;
			default:
				break;
			}



			GUILayout.EndVertical();

			GUILayout.Space(50);

			//Display buttons horizontally
			GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			DisplayButtons();
			GUILayout.EndHorizontal();

			GUILayout.EndVertical();
		}



		void DisplayNewWeapon()
		{
			tempWeapon.OnGUI();
		}



		void DisplayButtons()
		{
			if (!showNewWeaponDetails)
			{
				if (GUILayout.Button("Create Weapon"))
				{
					tempWeapon = new ISWeapon();
					showNewWeaponDetails = true;
					state = DisplayState.DETAILS;
				}
			}
			else
			{
				if (GUILayout.Button("Save"))
				{
					if(_selectedIndex == -1)
						weaponDatabase.Add (tempWeapon);
					else
						weaponDatabase.Replace(_selectedIndex, tempWeapon);
					
					showNewWeaponDetails = false;
					tempWeapon = null;
					_selectedIndex = -1;
					state = DisplayState.NONE;
				}
				
				if (GUILayout.Button("Cancel"))
				{
					showNewWeaponDetails = false;
					tempWeapon = null;
					_selectedIndex = -1;
					state = DisplayState.NONE;
				}
			}
		}
	}
}