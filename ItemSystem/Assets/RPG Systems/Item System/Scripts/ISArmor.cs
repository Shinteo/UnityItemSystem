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
			_prefab = new GameObject();
			equipmentSlot = EquipmentSlot.Feet;
		}



		#region IISGameObject implementation

		public GameObject Prefab {
			get {
				throw new System.NotImplementedException ();
			}
		}

		#endregion

		#region IISDestructable implementation

		public void TakeDamage (int amount)
		{
			throw new System.NotImplementedException ();
		}

		public void Repair ()
		{
			throw new System.NotImplementedException ();
		}

		public void Break ()
		{
			throw new System.NotImplementedException ();
		}

		public int Durability {
			get {
				throw new System.NotImplementedException ();
			}
		}

		public int MaxDurability {
			get {
				throw new System.NotImplementedException ();
			}
		}

		#endregion

		#region IISArmor implementation
		public Vector2 Armor {
			get {
				throw new System.NotImplementedException ();
			}
			set {
				throw new System.NotImplementedException ();
			}
		}
		#endregion
		
	}
}