using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem
{
	public interface IISEquipmentSlot
	{
		string EQSlotName { get; set; }
		Sprite EQSlotIcon { get; set; }
	}
}
