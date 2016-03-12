using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem
{
	[System.Serializable]
	public class ISMaterial : IISMaterial
	{
		#region IISMaterial implementation

		[SerializeField] string 	_MatName;
		[SerializeField] Sprite 	_MatIcon;
		[SerializeField] int 		_MatValue;
		[SerializeField] int		_MatWeight;



		string IISMaterial.ItemName 
		{
			get { return _MatName; }
			set { _MatName = value;}
		}



		int IISMaterial.ItemValue 
		{
			get { return _MatValue; }
			set { _MatValue = value;}
		}



		Sprite IISMaterial.ItemIcon
		{
			get { return _MatIcon; }
			set { _MatIcon = value;}
		}

		


		int IISMaterial.ItemWeight 
		{
			get { return _MatWeight; }
			set { _MatWeight = value;}
		}

		#endregion
	}
}