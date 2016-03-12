using UnityEditor;
using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor : EditorWindow 
	{		
		ISWeaponDatabase weaponDatabase;
		ISObjectCategory armorDatabase = new ISObjectCategory();
		ISMaterialDatabase materialDatabase;


		//This defines the location of the database to save to
		const string WEAPON_DATABASE_NAME 		= @"RPGWeaponDatabase.asset";
		const string MATERIAL_DATABASE_NAME		= @"RPGMaterialDatabase.asset";

		const string DATABASE_PATH 				= @"Database";
		const string DATABASE_FULL_PATH 		= @"Assets/" + DATABASE_PATH + "/" + WEAPON_DATABASE_NAME;



		//Use this to set the main editor window
		[MenuItem("RPG/Database/Item Database Editor %#i")]
		public static void Init()
		{
			ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor> ();
			window.minSize = new Vector2 (800, 600);
			GUIContent titleContent = new GUIContent ("Item Database");
			window.titleContent = titleContent;
			window.Show ();
		}



		//Creates the database if there isn't one
		void OnEnable()
		{
			if (weaponDatabase == null)
				weaponDatabase = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DATABASE_PATH, WEAPON_DATABASE_NAME);

			if (materialDatabase == null)
				materialDatabase = ISMaterialDatabase.GetDatabase<ISMaterialDatabase>(DATABASE_PATH, MATERIAL_DATABASE_NAME);

			armorDatabase.OnEnable();

			tabState = TabState.WEAPON;
		}



		//The actual editor view box in Unity
		void OnGUI()
		{
			TopTabBar();

			GUILayout.BeginHorizontal();

			switch (tabState)
			{
			case TabState.WEAPON:
				ListView();
				ItemDetails();
				break;
			case TabState.ARMOR:
				armorDatabase.Listview(buttonSize);
				armorDatabase.ItemDetail();
				break;
			case TabState.CONSUMABLE:
				GUILayout.Label("Consumable");
				break;
			case TabState.MATERIAL:
				GUILayout.Label("Material");
				break;
			default:
				GUILayout.Label("Default -> About");
				break;
			}
				
			GUILayout.EndHorizontal();

			BottomBar();
		}
	}
}