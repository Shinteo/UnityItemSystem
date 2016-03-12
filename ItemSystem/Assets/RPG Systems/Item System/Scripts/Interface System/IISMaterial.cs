using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem
{
	public interface IISMaterial
	{
		//name
		//value - gold value
		//icon
		//weight
		string 		ItemName 		{ get; set; }
		int			ItemValue 		{ get; set; }
		Sprite 		ItemIcon 		{ get; set; }
		int 		ItemWeight 		{ get; set; }
	}
}