//connect to database
//Spawn item from the database



using UnityEngine;
using System.Collections;
using RPGSystem.ItemSystem;


//Only allow one component
[DisallowMultipleComponent]
public class Demo1 : MonoBehaviour
{
	public ISWeaponDatabase weaponDatabase;



	void OnGUI()
	{
		for (int cnt = 0; cnt < weaponDatabase.Count; cnt++)
			if (GUILayout.Button("Spawn: " + weaponDatabase.Get(cnt).ItemName))
		{
			Spawn(cnt);
		}
	}



	void Spawn(int index)
	{
		ISWeapon isw = weaponDatabase.Get(index);

		GameObject weapon = Instantiate(isw.Prefab);
		weapon.name = isw.ItemName;

		Weapon myWeapon = weapon.AddComponent<Weapon>();

		myWeapon.WeaponIcon 		= isw.ItemIcon;
		myWeapon.Value 				= isw.ItemValue;
		myWeapon.Weight 			= isw.ItemWeight;
		myWeapon.QualityIcon 		= isw.ItemQuality.Icon;
		myWeapon.Min_Damage 		= isw.MinDamage;
		myWeapon.Durability 		= isw.Durability;
		myWeapon.Max_Durabilty 		= isw.MaxDurability;
		myWeapon.EquipmentSlot 		= isw.equipmentSlot;
	}
}