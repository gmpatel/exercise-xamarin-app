using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using PersonalContacts.Classes;
using PersonalContacts.Global;

using SQLite;

namespace PersonalContacts
{
	[Activity (Label = "Contacts", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Sensor)]
	public class MainActivity : Activity
	{
		DbHelper dbHelper;
		List<Contact> contacts;

		protected override void OnCreate (Bundle bundle)
		{
			dbHelper = new DbHelper ();
			contacts = dbHelper.GetContacts();

			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			var listViewData = FindViewById<ListView> (Resource.Id.listViewData);

			listViewData.Adapter = new DataAdapter(this, contacts);
			listViewData.ItemClick += OnListItemClick;
		}

		protected void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			Android.Widget.Toast.MakeText(this, contacts[e.Position].GetFullName(), Android.Widget.ToastLength.Short).Show();
		
			var contactDetails = new Intent (this, typeof(ContactDetailsActivity));
			contactDetails.PutExtra ("ContactId", contacts[e.Position].Id);
			StartActivity (contactDetails);
		}
	}
}