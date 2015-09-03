using System;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using System.Threading.Tasks;

namespace MarvelComicCalanderUpdater {
	class MarvelApi {

		private string publicKey = ConfigurationManager.AppSettings["publicKey"];
		private string privateKey = ConfigurationManager.AppSettings["privateKey"];
		private RestClient Client;

		public MarvelApi() {
			Client = new RestClient("http://gateway.marvel.com/v1/public/");
		}

		private RestResponse<T> APIRequest<T>(RestRequest request) where T : new() {
			string timeStamp = Math.Floor((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
			request.AddParameter("ts", timeStamp);
			request.AddParameter("apikey", publicKey);
			request.AddParameter("hash", getMD5(timeStamp));

			RestResponse<T> response = (RestResponse<T>)Client.Execute<T>(request);
			return response;
		}


		public List<Series.Result> searchSeries(string searchTerm) {
			RestRequest seriesRequest = new RestRequest("/series", Method.GET);
			seriesRequest.AddParameter("title", searchTerm);
			RestResponse<Series.RootObject> response = APIRequest<Series.RootObject>(seriesRequest);
			List<Series.Result> seriesList = response.Data.data.results;
			return seriesList;
		}

		public List<Comics.Result> searchComics(string searchTerm) {
			RestRequest comicsRequest = new RestRequest("/comics", Method.GET);
			comicsRequest.AddParameter("title", searchTerm);
			RestResponse<Comics.RootObject> response = APIRequest<Comics.RootObject>(comicsRequest);
			List<Comics.Result> comicsList = response.Data.data.results;
			return comicsList;
		}

		private string getMD5(string timeStamp) {
			using (MD5 md5Hash = MD5.Create()) {
				// Convert the input string to a byte array and compute the hash. 
				byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(timeStamp + privateKey + publicKey));

				// Create a new Stringbuilder to collect the bytes 
				// and create a string.
				StringBuilder sBuilder = new StringBuilder();

				// Loop through each byte of the hashed data  
				// and format each one as a hexadecimal string. 
				for (int i = 0; i < data.Length; i++) {
					sBuilder.Append(data[i].ToString("x2"));
				}

				// Return the hexadecimal string. 
				return sBuilder.ToString();
			}
		}
	}
}
