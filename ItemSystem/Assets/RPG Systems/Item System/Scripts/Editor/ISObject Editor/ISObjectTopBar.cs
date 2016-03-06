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



		void AboutTab()
		{
			GUILayout.Button("About");
		}
	}
}
