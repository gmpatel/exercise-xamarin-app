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
	[Activity (Label = "Contact Details", ScreenOrientation = Android.Content.PM.ScreenOrientation.Sensor)]			
	public class ContactDetailsActivity : Activity
	{
		int contactId = 0;

		DbHelper dbHelper;
		Contact contact;

		TextView txtFullName;
		TextView txtHomeAddress;
		TextView txtSuburb;
		TextView txtState;
		TextView txtCountry;
		TextView txtHomePhone;
		TextView txtWorkPhone;
		TextView txtMobile;
		TextView txtEmail;
		TextView txtLinkedInUrl;
		TextView txtFacebookUrl;
		ImageView imgHomeAddressMap;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.ContactDetails);

			contactId = Intent.GetIntExtra ("ContactId", -1);

			txtFullName = FindViewById<TextView> (Resource.Id.txtFullName);
			txtHomeAddress = FindViewById<TextView> (Resource.Id.txtHomeAddress);
			txtSuburb = FindViewById<TextView> (Resource.Id.txtSuburb);
			txtState = FindViewById<TextView> (Resource.Id.txtState);
			txtCountry = FindViewById<TextView> (Resource.Id.txtCountry);
			txtHomePhone = FindViewById<TextView> (Resource.Id.txtHomePhone);
			txtWorkPhone = FindViewById<TextView> (Resource.Id.txtWorkPhone);
			txtMobile = FindViewById<TextView> (Resource.Id.txtMobile);
			txtEmail = FindViewById<TextView> (Resource.Id.txtEmail);
			txtLinkedInUrl = FindViewById<TextView> (Resource.Id.txtLinkedInUrl);
			txtFacebookUrl = FindViewById<TextView> (Resource.Id.txtFacebookUrl);
			imgHomeAddressMap = FindViewById<ImageView> (Resource.Id.imgHomeAddressMap);

			dbHelper = new DbHelper ();
			contact = dbHelper.GetContact(contactId);

			Android.Widget.Toast.MakeText(this, string.Format("{0} : {1}", contact.Id, contact.GetFullName()), Android.Widget.ToastLength.Short).Show();

			DisplayContact ();

			txtHomePhone.Click += OnPhoneClick;
			txtWorkPhone.Click += OnPhoneClick;
			txtMobile.Click += OnPhoneClick;

			txtLinkedInUrl.Click += OnLinkClick;
			txtFacebookUrl.Click += OnLinkClick;

			txtHomeAddress.Click += OnAddressClick;
			txtSuburb.Click += OnAddressClick;
			txtState.Click += OnAddressClick;
			txtCountry.Click += OnAddressClick;
			imgHomeAddressMap.Click += OnMapImageClick;

			txtEmail.Click += OnEmailClick;
		}

		protected void OnEmailClick(object sender, EventArgs e)
		{
			var email = ((TextView)sender).Text;

			if(!string.IsNullOrEmpty(email))
			{
				try
				{
					var emailIntent = new Intent (Android.Content.Intent.ActionSend);
					emailIntent.PutExtra (Android.Content.Intent.ExtraEmail, new string[]{email} );
					emailIntent.SetType ("message/rfc822");
					StartActivity (emailIntent);
				}
				catch(Exception ex)
				{
					Android.Widget.Toast.MakeText(this, string.Format("Exception : {0}", ex.Message), Android.Widget.ToastLength.Short).Show();
				}
			}
		}

		protected void OnMapImageClick(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty (contact.GetFullAddress ())) 
			{
				try
				{
					var uri = Android.Net.Uri.Parse (string.Format("https://www.google.com/maps/place/{0}", contact.GetFullAddress()));
					var intent = new Intent (Intent.ActionView, uri); 
					StartActivity (intent);  
				}
				catch(Exception ex) 
				{
					Android.Widget.Toast.MakeText(this, string.Format("Exception : {0}", ex.Message), Android.Widget.ToastLength.Short).Show();
				}
			}
		}

		protected void OnAddressClick(object sender, EventArgs e)
		{
			var address = ((TextView)sender).Text;

			if(!string.IsNullOrEmpty(address) && !string.IsNullOrEmpty (contact.GetFullAddress ()))
			{
				try
				{
					var uri = Android.Net.Uri.Parse (string.Format("https://www.google.com/maps/place/{0}", contact.GetFullAddress()));
					var intent = new Intent (Intent.ActionView, uri); 
					StartActivity (intent);  
				}
				catch(Exception ex) 
				{
					Android.Widget.Toast.MakeText(this, string.Format("Exception : {0}", ex.Message), Android.Widget.ToastLength.Short).Show();
				}
			}
		}

		protected void OnLinkClick(object sender, EventArgs e)
		{
			var url = ((TextView)sender).Text;

			if(!string.IsNullOrEmpty(url))
			{
				try
				{
					var uri = Android.Net.Uri.Parse (url);
					var intent = new Intent (Intent.ActionView, uri); 
					StartActivity (intent);  
				}
				catch(Exception ex) 
				{
					Android.Widget.Toast.MakeText(this, string.Format("Exception : {0}", ex.Message), Android.Widget.ToastLength.Short).Show();
				}
			}
		}

		protected void OnPhoneClick(object sender, EventArgs e)
		{
			string phoneNumber = ((TextView)sender).Text;

			if (!string.IsNullOrEmpty(phoneNumber)) 
			{
				try
				{
					var uri = Android.Net.Uri.Parse (string.Format("tel:{0}", phoneNumber));
					var intent = new Intent (Intent.ActionView, uri); 
					StartActivity (intent);  
				}
				catch(Exception ex) 
				{
					Android.Widget.Toast.MakeText(this, string.Format("Exception : {0}", ex.Message), Android.Widget.ToastLength.Short).Show();
				}
			}
		}

		private void DisplayContact()
		{
			txtFullName.Text = contact.GetFullName ();
			txtHomeAddress.Text = contact.HomeAddress;
			txtSuburb.Text = contact.Suburb;
			txtState.Text = contact.GetFullState ();
			txtCountry.Text = contact.Country;
			txtHomePhone.Text = contact.HomePhone.ToString();
			txtWorkPhone.Text = contact.WorkPhone.ToString();
			txtMobile.Text = contact.Mobile.ToString();
			txtEmail.Text = contact.Email;
			txtLinkedInUrl.Text = contact.LinkedInURL;
			txtFacebookUrl.Text = contact.FacebookURL;
		}
	}
}