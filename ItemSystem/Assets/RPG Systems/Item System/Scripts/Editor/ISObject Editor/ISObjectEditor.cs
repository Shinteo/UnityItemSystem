using UnityEditor;
using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor : EditorWindow 
	{		
		ISWeaponDatabase weaponDatabase;
		//Vector2 _scrollPos; 				//scroll posistion for list view 



		const string DATABASE_NAME 			= @"RPGWeaponDatabase.asset";
		const string DATABASE_PATH 			= @"Database";
		const string DATABASE_FULL_PATH 	= @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;



		//Use this to set the editor window
		[MenuItem("RPG/Database/Item Database Editor %#i")]
		public static void Init()
		{
			ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor> ();
			window.minSize = new Vector2 (800, 600);
			GUIContent titleContent = new GUIContent ("Item Database");
			window.titleContent = titleContent;
			window.Show ();
		}



		void OnEnable()
		{
			if (weaponDatabase == null)
				weaponDatabase = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DATABASE_PATH, DATABASE_NAME);
		}



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