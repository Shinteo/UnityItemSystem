using UnityEngine;
using System.Collections;


namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectCategory 
	{
		protected ISArmorDatabase Database 	{ get; set; }	//the database
		protected string DatabaseName 		{ get; set; }	//the name of the database

		const string DATABASE_PATH 			= @"Database";	//the path of the database


		//Initialize a new instance of the ISObjectCategory class
		public ISObjectCategory()
		{
			DatabaseName = @"RPGArmorDatabase.asset";
		}


		//Gets the full path to the database
		public string DatabaseFullPath
		{
			get { return @"Assets/" + DATABASE_PATH + "/" + DatabaseName; }
		}



		//Creates the database if there isn't one on enable
		public void OnEnable()
		{
			if (Database == null)
				Database = ISArmorDatabase.GetDatabase<ISArmorDatabase> (DATABASE_PATH, DatabaseName);
		}



		//Show the list and detail page
		public void OnGUI()
		{
			Listview(buttonSize);
			ItemDetail();
		}
	}
}