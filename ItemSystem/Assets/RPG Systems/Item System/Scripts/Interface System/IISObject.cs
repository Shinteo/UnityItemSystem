using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem
{
	public interface IISObject 
	{
		//name
		//value - gold value
		//icon
		//weight
		//quality of item
		string 		ItemName 		{ get; set; }
		int			ItemValue 		{ get; set; }
		Sprite 		ItemIcon 		{ get; set; }
		int 		ItemWeight 		{ get; set; }
		ISQuality 	ItemQuality 	{ get; set; }
	}
}
