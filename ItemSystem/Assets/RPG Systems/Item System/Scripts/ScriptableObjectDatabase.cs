using UnityEditor;					//Needed for EditorUtility
using UnityEngine;
using System.Linq; 					//Needed for ElementAt
using System.Collections;
using System.Collections.Generic;	//Needed for List



namespace RPGSystem
{
	public class ScriptableObjectDatabase<T> : ScriptableObject where T: class
	{
		[SerializeField] protected List<T> database = new List<T>();

		//Use this to add item to the Quality Database
		public void Add( T item)
		{
			database.Add (item);
			EditorUtility.SetDirty (this);
		}
		
		
		
		//Use this to add item in between items in the Quality Database
		public void Insert (int index, T item)
		{
			database.Insert (index, item);
			EditorUtility.SetDirty (this);
		}

		
		
		//Use this to remove an item from the Quality Database
		public void Remove (T item)
		{
			database.Remove (item);
			EditorUtility.SetDirty (this);
		}
		
		
		
		//Use this to remove a specific item from the Quality Database
		public void Remove (int index)
		{
			database.RemoveAt (index);
			EditorUtility.SetDirty (this);
		}
		
		
		
		//Use this to get the number of items in the database
		public int Count
		{
			get { return database.Count;}
		}
		
		

		//Use this to get a specific item from the database
		public T Get (int index)
		{
			return database.ElementAt (index);
		}
		

		
		//Use this to replace an item in the database with another
		public void Replace (int Index, T item)
		{
			database [Index] = item;
			EditorUtility.SetDirty (this);
		}

		

		//
		public static U GetDatabase<U>(string dbPath, string dbName) where U : ScriptableObject
		{
			string dbFullPath = @"Assets/" +dbPath + "/" + dbName;

			U db = AssetDatabase.LoadAssetAtPath (dbFullPath, typeof(U)) as U;
			
			//If the database is missing, create new database
			if (db == null) 
			{
				//check to see if the folder exist
				if (!AssetDatabase.IsValidFolder("Assets/" + dbPath))
					AssetDatabase.CreateFolder("Assets", dbPath);
				
				db = ScriptableObject.CreateInstance<U> () as U;
				AssetDatabase.CreateAsset(db, dbFullPath);
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}

			return db;
		}



		//Use this to clear the database
		public void ClearDatabase()
		{
			database.Clear();
			database.TrimExcess ();
			EditorUtility.SetDirty (this);
		}
	}
}