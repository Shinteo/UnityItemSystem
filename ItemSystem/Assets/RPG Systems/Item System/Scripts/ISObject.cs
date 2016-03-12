using UnityEditor;
using UnityEngine;
using System.Collections;

namespace RPGSystem.ItemSystem
{
	[System.Serializable]
	public class ISObject : IISObject 
	{
		#region IISObject implementation

		[SerializeField] string 	_name;
		[SerializeField] Sprite 	_icon;
		[SerializeField] int 		_value;
		[SerializeField] int 		_weight;
		[SerializeField] ISQuality 	_quality;



		public ISObject (ISObject item)
		{
			Clone (item);
		}



		public void Clone (ISObject item)
		{
			_name		= item.ItemName;
			_icon		= item.ItemIcon;
			_value		= item.ItemValue;
			_weight		= item.ItemWeight;
			_quality	= item.ItemQuality;
		}



		public string ItemName 
		{
			get { return _name;}
			set { _name = value;}
		}



		public int ItemValue 
		{
			get { return _value;}
			set { _value = value;}
		}



		public Sprite ItemIcon 
		{
			get { return _icon;}
			set { _icon = value;}
		}



		public int ItemWeight 
		{
			get { return _weight;}
			set { _weight = value;}
		}



		public ISQuality ItemQuality 
		{
			get { return _quality;}
			set { _quality = value;}
		}



		//This code is going to be place in a new class later on
		ISQualityDatabase qdb;
		int qualitySelectedIndex = 0;
		string[] option;


		public virtual void OnGUI()
		{
			//GUILayout.BeginVertical();
			_name 		= EditorGUILayout.TextField("Name", _name);
			_value 		= EditorGUILayout.IntField("Value", _value);
			_weight 	= EditorGUILayout.IntField("Weight", _weight);

			DisplayIcon();
			DisplayQuality();
			//GUILayout.EndVertical();
		}




		public void DisplayIcon()
		{
			_icon = EditorGUILayout.ObjectField("Prefab", _icon, typeof (Sprite), false) as Sprite;
		}



		public int SelectedQualityID
		{
			get { return qualitySelectedIndex;}
		}



		public ISObject()
		{
			string DATABASE_NAME 	= @"RPGQualityDatabase.asset";
			string DATABASE_PATH 	= @"Database";
			qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);

			option = new string[qdb.Count] ;
			for (int cnt = 0; cnt < qdb.Count; cnt ++)
				option[cnt] = qdb.Get (cnt).Name;
		}



		public void DisplayQuality()
		{
			int itemIndex = 0;

			if (_quality != null)
				itemIndex = qdb.GetIndex (_quality.Name);
			
			qualitySelectedIndex = EditorGUILayout.Popup("Quality", itemIndex , option);
			_quality = qdb.Get(SelectedQualityID);
		}
		#endregion
	}
}