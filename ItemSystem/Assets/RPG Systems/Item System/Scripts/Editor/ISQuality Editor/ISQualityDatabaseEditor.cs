using UnityEditor;
using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISQualityDatabaseEditor : EditorWindow 
	{
		ISQualityDatabase qualityDatabase;
		Texture2D selectedTexture;
		int selectedIndex = -1;
		Vector2 _scrollPos; 				//scroll posistion for list view 



		const int SPRITE_BUTTON_SIZE = 46;

		const string DATABASE_NAME 	= @"RPGQualityDatabase.asset";
		const string DATABASE_PATH 	= @"Database";



		//Use this to set the editor window
		[MenuItem("RPG/Database/Quality Editor %#w")]
		public static void Init()
		{
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor> ();
			window.minSize = new Vector2 (400, 300);
			GUIContent titleContent = new GUIContent ("Quality Database");
			window.titleContent = titleContent;
			window.Show ();
		}



		void OnEnable()
		{
			if (qualityDatabase == null)
				qualityDatabase = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);
		}



		void OnGUI()
		{
			//In case of when GUI fires before OnEnable above
			if (qualityDatabase == null)
			{
				Debug.Log ("QualityDatabase not loaded");
				return;
			}

			ListView ();

			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			BottomBar();
			GUILayout.EndHorizontal();
		}

		void BottomBar()
		{
			//Count
			GUILayout.Label("Num of qualities: " + qualityDatabase.Count);

			//Add Button
			if(GUILayout.Button("Add"))
			{
				qualityDatabase.Add (new ISQuality());
			}
		}
	}
}