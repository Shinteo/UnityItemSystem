using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem
{
	public class ISEquipmentSlot : IISEquipmentSlot
	{
		[SerializeField] string _name;
		[SerializeField] Sprite _icon;



		public ISEquipmentSlot()
		{
			_name = "Name Me";
			_icon = new Sprite ();
		}



		public string EQSlotName 
		{
			get { return _name; }
			set { _name = value; }
		}

		public Sprite EQSlotIcon 
		{
			get { return _icon; }
			set { _icon = value; }
		}
	}
}
