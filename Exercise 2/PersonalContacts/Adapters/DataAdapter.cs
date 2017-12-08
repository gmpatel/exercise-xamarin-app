using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using PersonalContacts.Classes;

namespace PersonalContacts
{
	public class DataAdapter : BaseAdapter<Contact> 
	{
		List<Contact> contacts;
		Activity context;

		public DataAdapter(Activity context, List<Contact> contacts) : base()
		{
			this.context = context;
			this.contacts = contacts;
		}

		public override long GetItemId(int position)
		{
			return position;
		}
		public override Contact this[int position]
		{
			get { return contacts[position]; }
		}
		public override int Count
		{
			get { return contacts.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = contacts[position];
			var view = convertView;

			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.Row, null);

			view.FindViewById<TextView> (Resource.Id.contactName).Text = string.Format(item.GetFullName());
			view.FindViewById<TextView>(Resource.Id.contactMobile).Text = item.Mobile.ToString();
			view.FindViewById<TextView>(Resource.Id.contactEmail).Text = item.Email.ToString();

			return view;
		}
	}
}