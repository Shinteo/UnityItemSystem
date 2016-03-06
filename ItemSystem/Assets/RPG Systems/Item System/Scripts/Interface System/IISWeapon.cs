using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem
{
	public interface IISWeapon
	{
		int MinDamage { get; set; }
		int Attack();

	}
}
