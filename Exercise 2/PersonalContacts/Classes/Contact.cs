
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

using SQLite;

namespace PersonalContacts.Classes
{
	public class Contact
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string HomeAddress { get; set; }
		public string Suburb { get; set; }
		public long Postcode { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public long HomePhone { get; set; }
		public long WorkPhone  { get; set; }
		public long Mobile { get; set; }
		public string Email { get; set; }
		public string LinkedInURL { get; set; }
		public string FacebookURL { get; set; }
	
		public string GetFullName()
		{
			return string.Format ("{0} {1}", FirstName, LastName);
		}

		public string GetFullAddress()
		{
			return string.Format ("{0}, {1}, {2} {3}, {4}", HomeAddress, Suburb, State, Postcode, Country);
		}

		public string GetFullState()
		{
			return string.Format ("{0} {1}", State, Postcode);
		}
	}
}