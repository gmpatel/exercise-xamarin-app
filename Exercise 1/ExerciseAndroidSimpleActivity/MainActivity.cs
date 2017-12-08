using System;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Newtonsoft.Json;

using ExerciseAndroidSimpleActivity.Classes;
using ExerciseAndroidSimpleActivity.Adapters;
using ExerciseAndroidSimpleActivity.General;

namespace ExerciseAndroidSimpleActivity
{
	[Activity (Label = "Customer List (By, Gunjan Patel)", MainLauncher = true)]
	public class MainActivity : Activity
	{
		Data data;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			data = MyWebRequest.RequestJsonWebService<Data>("http://mono.servicestack.net/ServiceStack.Northwind/customers?format=json");

			SetContentView (Resource.Layout.Main);

			var listViewData = FindViewById<ListView>(Resource.Id.listViewData);

			if (data != null && data.Customers.Count > 0) 
			{
				listViewData.Adapter = new DataAdapter(this, data.Customers);
			}

			listViewData.ItemClick += OnListItemClick;
		}

		protected void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			Android.Widget.Toast.MakeText(this, data.Customers[e.Position].CompanyName, Android.Widget.ToastLength.Short).Show();
		}
	}
}