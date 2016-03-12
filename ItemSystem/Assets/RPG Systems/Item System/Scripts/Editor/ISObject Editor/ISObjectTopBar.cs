using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		void TopTabBar()
		{
			//The tabs that are at the top of the editor
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

			WeaponTab();
			ArmorTab();
			ConsumableTab();
			MaterialTab();
			AboutTab();

			GUILayout.EndHorizontal();
		}



		void WeaponTab()
		{
			GUILayout.Button ("Weapon");
		}



		void ArmorTab()
		{
			GUILayout.Button("Armors");
		}



		void ConsumableTab()
		{
			GUILayout.Button("Consumable");
		}



		void MaterialTab()
		{
			GUILayout.Button("Material");
		}



		void AboutTab()
		{
			GUILayout.Button("About");
		}
	}
}
