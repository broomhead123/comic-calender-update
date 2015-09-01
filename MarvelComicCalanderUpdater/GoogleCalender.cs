using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MarvelComicCalanderUpdater {
	class GoogleCalender {

		string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarReadonly };
		string ApplicationName = "Google Calendar API Quickstart";


		public void CreateEvent(string eventName, string date) {
			//Create new API Service
			CalendarService service = createCalenderService();

			//Create new event
			Event newEvent = new Event(){Summary = eventName};
			newEvent.Start = new EventDateTime() { DateTime = Convert.ToDateTime(date), TimeZone = "Europe/London" };
			newEvent.End = new EventDateTime() { DateTime = Convert.ToDateTime(date), TimeZone = "Europe/London" };
			newEvent = service.Events.Insert(newEvent, "callum_collins@hotmail.com").Execute();
			Console.WriteLine("Event created: {0} \n", newEvent.HtmlLink);
		}

		private CalendarService createCalenderService() {

			UserCredential credential;
			using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read)) {
				string credPath = System.Environment.GetFolderPath(
					System.Environment.SpecialFolder.Personal);
				credPath = Path.Combine(credPath, ".credentials");

				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					Scopes,
					"user",
					CancellationToken.None,
					new FileDataStore(credPath, true)).Result;
			}

			// Create Google Calendar API service.
			var service = new CalendarService(new BaseClientService.Initializer() {
				HttpClientInitializer = credential,
				ApplicationName = ApplicationName,
			});
			
			return service;
		}
	}
}
