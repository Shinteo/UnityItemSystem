#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem
{
	[System.Serializable]
	public class ISArmor : ISObject, IISArmor, IISDestructable, IISGameObject
	{

		[SerializeField] int 				_currentArmor;
		[SerializeField] int 				_maxArmor;
		[SerializeField] int 				_durability;
		[SerializeField] int				_maxDurability;
		[SerializeField] GameObject 		_prefab;

		// Add the material here

		public EquipmentSlot equipmentSlot;



		public ISArmor ()
		{
			_currentArmor = 0;
			_maxArmor = 0;
			_durability = 1;
			_maxDurability = 1;

			equipmentSlot = EquipmentSlot.Feet;
		}



		public ISArmor (ISArmor armor)
		{
			Clone(armor);
		}



		public void Clone(ISArmor armor)
		{
			base.Clone(armor);

			_currentArmor	= armor._currentArmor;
			_maxArmor		= armor._maxArmor;
			_durability 	= armor.Durability;
			_maxDurability 	= armor.MaxDurability;
			equipmentSlot 	= armor.equipmentSlot;
			_prefab			= armor.Prefab;
		}



		#region IISGameObject implementation

		public GameObject Prefab 
		{
			get 
			{ 
				return _prefab; 
			}
		}

		#endregion



		#region IISDestructable implementation

		public void TakeDamage (int amount)
		{
			_durability -= amount;

			if (_durability < 0)
				_durability = 0;

			if (_durability == 0)
				Break ();
		}



		public void Repair ()
		{
			//This is set so that when you repair stuff, the max durability gets reduced
			_maxDurability --;

			if (_maxDurability > 0)
				_durability = _maxDurability;
		}



		//reduce the duribility to 0
		public void Break ()
		{
			_durability = 0;
		}



		public int Durability 
		{
			get { return _durability; }
		}



		public int MaxDurability 
		{
			get { return _maxDurability; }
		}



		#endregion



		#region IISArmor implementation

		public Vector2 Armor {
			get 
			{return new Vector2 (_currentArmor, _maxArmor);}

			set 
			{
				if (value.x < 0)
					value.x = 0;
				if (value.y <1)
					value.y = 1;
				if (value.x > value.y)
					value.x = value.y;


				_currentArmor 	= (int) value.x;
				_maxArmor 		= (int) value.y;
			}
		}
		#endregion


		// This part will go to a new script later
#if UNITY_EDITOR
		public override void OnGUI()
		{
			base.OnGUI();

			_maxArmor	 	= EditorGUILayout.IntField("Max Armor", _maxArmor);
			_currentArmor 	= EditorGUILayout.IntField("Current Armor", _currentArmor);
			//If the Durability is more then Max Durability, spawn a error message, and then set the Durability to be same as Max Durability
			if (_currentArmor > _maxArmor)
			{
				EditorUtility.DisplayDialog ("Error", "Current Armor cannot be more then Max Armor", "OK");
				_currentArmor = _maxArmor;
				GUI.FocusControl (null);
			}

			_maxDurability 	= EditorGUILayout.IntField("Max Durability", _maxDurability);
			_durability 	= EditorGUILayout.IntField("Current Durabilty", _durability);
			//If the Durability is more then Max Durability, spawn a error message, and then set the Durability to be same as Max Durability
			if (_durability > _maxDurability)
			{
				EditorUtility.DisplayDialog ("Error", "Durability cannot be more then Max Durability", "OK");
				_durability = _maxDurability;
				GUI.FocusControl (null);
			}

			DisplayEquipmentSlot();
			DisplayPrefab();
		}



		public void DisplayEquipmentSlot()
		{
			equipmentSlot = (EquipmentSlot) EditorGUILayout.EnumPopup("Equipment Slot", equipmentSlot);
		}



		public void DisplayPrefab()
		{
			_prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof (GameObject), false) as GameObject;
		}

#endif
	}
}