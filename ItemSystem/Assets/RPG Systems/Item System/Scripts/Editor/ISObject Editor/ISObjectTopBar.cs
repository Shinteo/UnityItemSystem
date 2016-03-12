using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		enum TabState
		{
			WEAPON,
			ARMOR,
			CONSUMABLE,
			MATERIAL,
			ABOUT
		}



		TabState tabState;



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
			if (GUILayout.Button ("Weapon"))
				tabState = TabState.WEAPON;
		}



		void ArmorTab()
		{
			if (GUILayout.Button("Armor"))
				tabState = TabState.ARMOR;
		}



		void ConsumableTab()
		{
			if (GUILayout.Button("Consumable"))
				tabState = TabState.CONSUMABLE;
		}



		void MaterialTab()
		{
			if (GUILayout.Button("Material"))
				tabState = TabState.MATERIAL;
		}



		void AboutTab()
		{
			if (GUILayout.Button("About"))
				tabState = TabState.ABOUT;
		}
	}
}
