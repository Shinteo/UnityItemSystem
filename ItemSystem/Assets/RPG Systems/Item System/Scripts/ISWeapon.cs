#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem
{
	[System.Serializable]
	public class ISWeapon : ISObject, IISWeapon, IISDestructable, IISGameObject
	{
		#region IISWeapon implementation

		[SerializeField] int 				_minDamage;
		[SerializeField] int 				_durability;
		[SerializeField] int				_maxDurability;
		[SerializeField] GameObject 		_prefab;

		public WeaponMatList weaponMatList;

		public EquipmentSlot equipmentSlot;

		public ISWeapon()
		{
			_minDamage = 0;
			_durability = 1;
			_maxDurability = 1;
				
			equipmentSlot = EquipmentSlot.Feet;
		}



		public ISWeapon(ISWeapon weapon)
		{
			Clone(weapon);
		}



		public void Clone(ISWeapon weapon)
		{
			base.Clone(weapon);

			_minDamage		= weapon.MinDamage;
			_durability 	= weapon.Durability;
			_maxDurability 	= weapon.MaxDurability;
			equipmentSlot 	= weapon.equipmentSlot;
			weaponMatList	= weapon.weaponMatList;
			_prefab			= weapon.Prefab;
		}



		public int MinDamage 
		{
			get { return _minDamage; }
			set { _minDamage = value; }
		}



		public int Attack ()
		{
			throw new System.NotImplementedException ();
		}

		#endregion



		#region IISDestructable implementation

		public int Durability 
		{
			get { return _durability; }
		}



		public int MaxDurability 
		{
			get { return _maxDurability; }
		}



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
			_maxDurability --;

			if (_maxDurability > 0)
				_durability = _maxDurability;
		}



		//reduce the duribility to 0
		public void Break ()
		{
			_durability = 0;
		}
		#endregion



		#region IISGameObject implementation

		public GameObject Prefab 
		{
			get 
			{ 
				return _prefab; 
			}
		}



		// This part will go to a new script later
#if UNITY_EDITOR
		public override void OnGUI()
		{
			base.OnGUI();

			_minDamage 		= EditorGUILayout.IntField("Damage", _minDamage);
			_durability 	= EditorGUILayout.IntField("Durability", _durability);
			_maxDurability 	= EditorGUILayout.IntField("Max Durability", _maxDurability);

			//If the Durability is more then Max Durability, spawn a error message, and then set the Durability to be same as Max Durability
			if (_durability > _maxDurability)
			{
				EditorUtility.DisplayDialog ("Error", "Durability cannot be more then Max Durability", "OK");
				_durability = _maxDurability;
				GUI.FocusControl (null);
			}

			DisplayEquipmentSlot();
			DisplayWeaponMatList();
			DisplayPrefab();
		}



		public void DisplayEquipmentSlot()
		{
			equipmentSlot = (EquipmentSlot) EditorGUILayout.EnumPopup("Equipment Slot", equipmentSlot);
		}



		public void DisplayWeaponMatList()
		{
			weaponMatList = (WeaponMatList) EditorGUILayout.EnumPopup("Weapon Material", weaponMatList);
		}



		public void DisplayPrefab()
		{
			_prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof (GameObject), false) as GameObject;
		}

#endif

		#endregion
	}
}
