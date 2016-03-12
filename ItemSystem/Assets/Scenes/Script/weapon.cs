using UnityEngine;
using System.Collections;
using RPGSystem.ItemSystem;

[DisallowMultipleComponent]
public class Weapon : MonoBehaviour 
{
	public Sprite 
			WeaponIcon,
			QualityIcon;

	public int 
			Value,
			Weight,
			Min_Damage,
			Durability,
			Max_Durabilty;

	public EquipmentSlot EquipmentSlot;
}
