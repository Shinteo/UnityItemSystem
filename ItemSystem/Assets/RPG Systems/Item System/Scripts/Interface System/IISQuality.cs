using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem
{
	public interface IISQuality{
		//Name of quality
		//Icon of quality
		string Name { get; set; }
		Sprite Icon { get; set; }
	}
}