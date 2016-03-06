using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		ISWeapon tempWeapon = new ISWeapon();
		bool showNewWeaponDetails = false;



		void ItemDetails()
		{
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			GUILayout.BeginVertical(GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true));

			if (showNewWeaponDetails)
				DisplayNewWeapon();
					
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
				}
			}
			else
			{
				if (GUILayout.Button("Save"))
				{
					showNewWeaponDetails = false;

//					string DATABASE_NAME 	= @"RPGQualityDatabase.asset";
//					string DATABASE_PATH 	= @"Database";
//					ISQualityDatabase qdb;
//					qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);
//
//					tempWeapon.ItemQuality = qdb.Get(tempWeapon.SelectedQualityID);

					weaponDatabase.Add (tempWeapon);
					tempWeapon = null;
				}
				
				if (GUILayout.Button("Cancel"))
				{
					showNewWeaponDetails = false;
					tempWeapon = null;
				}
			}
		}
	}
}