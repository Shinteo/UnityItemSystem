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



		//Default state is NONE
		DisplayState state = DisplayState.NONE;



		void ItemDetails()
		{
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			GUILayout.BeginVertical(GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true));

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
				//This button shows up only when there is nothing selected. It'll allow you to create a new weapon
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
					//_selectedIndex == -1 means that the item is a brand new item
					//So we'll want to add it to the database
					if(_selectedIndex == -1)
						weaponDatabase.Add (tempWeapon);
					//else, since it is an exsisting item in the database, we should replace it
					else
						weaponDatabase.Replace(_selectedIndex, tempWeapon);

					//This is to reset everything to default
					showNewWeaponDetails = false;
					tempWeapon = null;
					_selectedIndex = -1;
					state = DisplayState.NONE;
					GUI.FocusControl ("Cancel");
				}


				//Only when the selected item is not a new item do the delete button comes up
				if(_selectedIndex != -1)
				{
					if (GUILayout.Button("Delete"))
					{
						if(EditorUtility.DisplayDialog(	"Delete Weapon", 
														"Are you sure that you want to delete " + weaponDatabase.Get(_selectedIndex).ItemName + " from the database?",
														"Delete",
														"Cancel"))
						{
							//This will remove the selected item by the index number
							weaponDatabase.Remove(_selectedIndex);

							//This is to reset everything to default
							showNewWeaponDetails = false;
							tempWeapon = null;
							_selectedIndex = -1;
							state = DisplayState.NONE;
							GUI.FocusControl ("Cancel");
						}
					}
				}



				//Set the next button to be the focus button
				GUI.SetNextControlName ("Cancel");

				if (GUILayout.Button("Cancel"))
				{
					showNewWeaponDetails = false;
					tempWeapon = null;
					_selectedIndex = -1;
					state = DisplayState.NONE;
					GUI.FocusControl ("Cancel");
				}
			}
		}
	}
}