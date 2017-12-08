using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using ExerciseAndroidSimpleActivity.Classes;

namespace ExerciseAndroidSimpleActivity.Adapters
{
	public class DataAdapter : BaseAdapter<Customer> 
	{
		List<Customer> customers;
		Activity context;

		public DataAdapter(Activity context, List<Customer> customers) : base()
		{
			this.context = context;
			this.customers = customers;
		}

		public override long GetItemId(int position)
		{
			return position;
		}
		public override Customer this[int position]
		{
			get { return customers[position]; }
		}
		public override int Count
		{
			get { return customers.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = customers[position];
			var view = convertView;

			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.Row, null);

			view.FindViewById<TextView>(Resource.Id.companyName).Text = item.CompanyName;
			view.FindViewById<TextView>(Resource.Id.contactName).Text = string.Format("{0}:", item.ContactName);
			view.FindViewById<TextView>(Resource.Id.contactTitle).Text = item.ContactTitle;
			view.FindViewById<TextView>(Resource.Id.address).Text = item.Address;
			view.FindViewById<TextView>(Resource.Id.city).Text = item.City;

			return view;
		}
	}
}