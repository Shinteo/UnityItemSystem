using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem
{
	public interface IISEquipable
	{
		ISEquipmentSlot EquipmentSlot { get; }
		bool Equip();
	}
}