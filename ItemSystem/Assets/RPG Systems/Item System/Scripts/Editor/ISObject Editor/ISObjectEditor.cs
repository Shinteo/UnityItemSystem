using UnityEditor;
using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor : EditorWindow 
	{		
		ISWeaponDatabase weaponDatabase;


		//This defines the location of the database to save to
		const string DATABASE_NAME 			= @"RPGWeaponDatabase.asset";
		const string DATABASE_PATH 			= @"Database";
		const string DATABASE_FULL_PATH 	= @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;



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
				weaponDatabase = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DATABASE_PATH, DATABASE_NAME);
		}



		//The actual editor view box in Unity
		void OnGUI()
		{
			TopTabBar();

			GUILayout.BeginHorizontal();

			ListView();
			ItemDetails();

			GUILayout.EndHorizontal();

			BottomBar();
		}
	}
}