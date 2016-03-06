using UnityEngine;
using System.Collections;


namespace RPGSystem.ItemSystem
{
	public interface IISStackable
	{
		int MaxStack { get; }
		int Stack (int amount); //default value of 0
	}
}
