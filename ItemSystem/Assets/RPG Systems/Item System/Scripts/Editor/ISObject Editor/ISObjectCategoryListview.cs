using UnityEngine;
using System.Collections;



namespace RPGSystem.ItemSystem.Editor
{
	public partial class ISObjectCategory 
	{
		int _selectedIndex 	= -1;						//-1 means that we have nothing selected
		ISArmor tempArmor;								//temp holder for the item we are working on
		bool showDetails 	= false;					//a flag to show that we show be showing the item details
		Vector2 _scrollPos 	= Vector2.zero;				//the pos of the scrollbar for the listview
		Vector2 buttonSize 	= new Vector2 (180, 25);	//the size of the button (lenght, height)
		int _listViewWidth 	= 200;						//width of the listview


		//Main code to display the list of items we have inside the database in the list view
		public void Listview(Vector2 buttonSize)
		{
			//To create a scroll bar
			_scrollPos = GUILayout.BeginScrollView (_scrollPos, "Box", GUILayout.ExpandHeight (true), GUILayout.Width(_listViewWidth));

			//The actual list itself
			for (int cnt = 0; cnt < Database.Count; cnt ++)
			{
				if(GUILayout.Button (Database.Get(cnt).ItemName, "box", GUILayout.Width(buttonSize.x), GUILayout.Height(buttonSize.y)))
				{
					_selectedIndex = cnt;
					tempArmor = new ISArmor (Database.Get(cnt));
					showDetails = true;
				}
			}

			GUILayout.EndScrollView();
		}
	}
}