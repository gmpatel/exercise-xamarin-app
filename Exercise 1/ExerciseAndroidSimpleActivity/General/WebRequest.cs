using System;
using System.Net;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Newtonsoft.Json;

namespace ExerciseAndroidSimpleActivity.General
{
	public static class MyWebRequest
	{
		public static T RequestJsonWebService<T>(string url)
		{ 
			var request = HttpWebRequest.Create(string.Format(@"{0}", url));
			request.ContentType = "application/json";
			request.Method = "GET";

			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			{
				if (response.StatusCode != HttpStatusCode.OK) 
				{
					Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);

					return default(T);
				}

				using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					var content = reader.ReadToEnd();

					if(string.IsNullOrWhiteSpace(content)) 
					{
						Console.Out.WriteLine("Response contained empty body...");

						return default(T);
					}
					else 
					{
						Console.Out.WriteLine("Response Body: {0} \r\n", content);

						try
						{
							return JsonConvert.DeserializeObject<T>(content);
						}
						catch(Exception ex)
						{
							Console.Out.WriteLine("Deserialization from JSON to type <T> failed: {0} \r\n", ex.Message);

							return default(T);
						}
					}
				}
			}
		}
	}
}