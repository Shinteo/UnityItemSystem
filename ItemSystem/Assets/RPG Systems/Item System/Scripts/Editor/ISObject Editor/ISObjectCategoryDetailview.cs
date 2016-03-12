using UnityEditor;
using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectCategory 
	{
		string strItemType = "Armor";



		public void ItemDetail()
		{
			GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			GUILayout.BeginVertical(GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true));


			if (showDetails)
				tempArmor.OnGUI();



			GUILayout.EndVertical();

			GUILayout.Space(50);

			//Display buttons horizontally
			GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			DisplayButton();
			GUILayout.EndHorizontal();

			GUILayout.EndVertical();
		}



		void DisplayButton()
		{
			if (showDetails)
			{
				ButtonSave();

				if(_selectedIndex != -1)
				{
					ButtonDelete();
				}

				ButtonCancel();
			}
			else
			{
				ButtonCreate();
			}
		}



		//Button for creating item
		void ButtonCreate()
		{
			//This button shows up only when there is nothing selected. It'll allow you to create a new weapon
			if (GUILayout.Button("Create " + strItemType))
			{
				tempArmor = new ISArmor();
				showDetails = true;
			}
		}



		//Button for saving item
		void ButtonSave()
		{
			if (GUILayout.Button("Save"))
			{
				//_selectedIndex == -1 means that the item is a brand new item
				//So we'll want to add it to the database
				if(_selectedIndex == -1)
					Database.Add (tempArmor);
				//else, since it is an exsisting item in the database, we should replace it
				else
					Database.Replace(_selectedIndex, tempArmor);

				//This is to reset everything to default
				showDetails = false;
				_selectedIndex = -1;
				tempArmor = null;

				//This sets the focus control to nothing, to prevent editor from keeping item in focus when you select something else
				GUI.FocusControl (null);
			}
		}



		//Button for canceling out of the details page
		void ButtonCancel()
		{
			if (GUILayout.Button("Cancel"))
			{
				showDetails = false;
				tempArmor = null;
				_selectedIndex = -1;

				//This sets the focus control to nothing, to prevent editor from keeping item in focus when you select something else
				GUI.FocusControl (null);
			}
		}



		void ButtonDelete()
		{
			if (GUILayout.Button("Delete"))
			{
				if(EditorUtility.DisplayDialog(	"Delete " + tempArmor.ItemName + "?", 
												"Are you sure that you want to delete " + tempArmor.ItemName + " from the database?", "Delete", "Cancel"))
				{
					//This will remove the selected item by the index number
					Database.Remove(_selectedIndex);

					//This is to reset everything to default
					showDetails = false;
					tempArmor = null;
					_selectedIndex = -1;

					//This sets the focus control to nothing, to prevent editor from keeping item in focus when you select something else
					GUI.FocusControl (null);
				}
			}
		}
	}
}