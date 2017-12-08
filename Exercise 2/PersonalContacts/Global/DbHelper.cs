using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PersonalContacts.Classes;

using SQLite;

namespace PersonalContacts.Global
{
	public class DbHelper
	{
		SQLiteConnection db;

		public DbHelper ()
		{
			var dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "contacts.db");
			this.db = new SQLiteConnection (dbPath);
			Seed ();
		}

		public Contact GetContact(int Id)
		{
			return db.Get<Contact>(Id);
		}

		public List<Contact> GetContacts()
		{
			var contacts = new List<Contact> ();

			foreach (var c in db.Table<Contact>()) 
				contacts.Add (c);

			return contacts;
		}

		private void Seed()
		{
			db.CreateTable<Contact> ();

			if (db.Table<Contact> ().Count () == 0) 
			{
				var c = new Contact 
				{
					FirstName = "Gunjan",
					LastName = "Patel",
					HomeAddress = "87-89 Lane St",
					Suburb = "Wentworthville",
					Postcode = 2145,
					State = "NSW",
					Country = "Australia",
					HomePhone = 61288683800,
					WorkPhone = 61288683804,
					Mobile = 61414854093,
					Email = "gmpat4u@gmil.com",
					LinkedInURL = "http://www.linkedin.com/profile/view?id=16814287",
					FacebookURL = "https://www.facebook.com/gmpat4u"
				};

				db.Insert (c);

				c = new Contact 
				{
					FirstName = "Aditi",
					LastName = "Patel",
					HomeAddress = "87-89 Lane St",
					Suburb = "Wentworthville",
					Postcode = 2145,
					State = "NSW",
					Country = "Australia",
					HomePhone = 61288683800,
					WorkPhone = 61288683804,
					Mobile = 61416759995,
					Email = "aditi4u@gmil.com",
					LinkedInURL = "http://www.linkedin.com/profile/view?id=40673985",
					FacebookURL = "https://www.facebook.com/aditi.patel.1023"
				};

				db.Insert (c);

				c = new Contact 
				{
					FirstName = "Chirag",
					LastName = "Patel",
					HomeAddress = "160 Grange Rd",
					Suburb = "Carnegie",
					Postcode = 3163,
					State = "VIC",
					Country = "Australia",
					HomePhone = 61389789054,
					WorkPhone = 61397654333,
					Mobile = 61456748389,
					Email = "kanchi7880@gmil.com",
					LinkedInURL = "http://www.linkedin.com/profile/view?id=16827890",
					FacebookURL = "https://www.facebook.com/kanchi7880"
				};

				db.Insert (c);

				c = new Contact 
				{
					FirstName = "Jignesh",
					LastName = "Patel",
					HomeAddress = "69 Essington St",
					Suburb = "Wentworthville",
					Postcode = 2145,
					State = "NSW",
					Country = "Australia",
					HomePhone = 61289447388,
					WorkPhone = 61389473632,
					Mobile = 61415769403,
					Email = "patel.jc@gmil.com",
					LinkedInURL = "http://www.linkedin.com/profile/view?id=2856212",
					FacebookURL = "https://www.facebook.com/patel.jc"
				};

				db.Insert (c);

				c = new Contact 
				{
					FirstName = "Kajal",
					LastName = "Patel",
					HomeAddress = "69 Essington St",
					Suburb = "Wentworthville",
					Postcode = 2145,
					State = "NSW",
					Country = "Australia",
					HomePhone = 61289447388,
					WorkPhone = 61389473632,
					Mobile = 61484567940,
					Email = "kaj1108@yahoo.com",
					LinkedInURL = "http://www.linkedin.com/profile/view?id=108924623",
					FacebookURL = "https://www.facebook.com/profile.php?id=706010945"
				};

				db.Insert (c);
			}
		}
	}
}