using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Configuration;
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
        private string calenderAddress = ConfigurationManager.AppSettings["calenderAddress"];

		public void CreateEvent(string eventName, string date) {
			//Create new API Service
			CalendarService service = createCalenderService();
            //check if even already exists
            EventsResource.ListRequest eventListRequest = service.Events.List("calenderAddress");
            Events eventList = eventListRequest.Execute();
            bool duplicate = eventList.Items.Any(x => x.Summary == eventName);

            if (duplicate == false) {
			    //Create new event (all day event)
			    Event newEvent = new Event(){Summary = eventName};
                newEvent.Start = new EventDateTime();
                newEvent.End = new EventDateTime();

		    	newEvent.Start.Date = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                newEvent.End.Date = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
                newEvent = service.Events.Insert(newEvent, "calenderAddress").Execute();
            }   
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
