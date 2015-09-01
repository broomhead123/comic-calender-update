using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComicCalanderUpdater {
	class Comics {
		public class TextObject {
			public string type { get; set; }
			public string language { get; set; }
			public string text { get; set; }
		}

		public class Url {
			public string type { get; set; }
			public string url { get; set; }
		}

		public class Series {
			public string resourceURI { get; set; }
			public string name { get; set; }
		}

		public class Variant {
			public string resourceURI { get; set; }
			public string name { get; set; }
		}

		public class Collection {
			public string resourceURI { get; set; }
			public string name { get; set; }
		}

		public class CollectedIssue {
			public string resourceURI { get; set; }
			public string name { get; set; }
		}

		public class Date {
			public string type { get; set; }
			public string date { get; set; }
		}

		public class Price {
			public string type { get; set; }
			public string price { get; set; }
		}

		public class Thumbnail {
			public string path { get; set; }
			public string extension { get; set; }
		}

		public class Image {
			public string path { get; set; }
			public string extension { get; set; }
		}

		public class Item {
			public string resourceURI { get; set; }
			public string name { get; set; }
			public string role { get; set; }
		}

		public class Creators {
			public string available { get; set; }
			public string returned { get; set; }
			public string collectionURI { get; set; }
			public List<Item> items { get; set; }
		}

		public class Item2 {
			public string resourceURI { get; set; }
			public string name { get; set; }
			public string role { get; set; }
		}

		public class Characters {
			public string available { get; set; }
			public string returned { get; set; }
			public string collectionURI { get; set; }
			public List<Item2> items { get; set; }
		}

		public class Item3 {
			public string resourceURI { get; set; }
			public string name { get; set; }
			public string type { get; set; }
		}

		public class Stories {
			public string available { get; set; }
			public string returned { get; set; }
			public string collectionURI { get; set; }
			public List<Item3> items { get; set; }
		}

		public class Item4 {
			public string resourceURI { get; set; }
			public string name { get; set; }
		}

		public class Events {
			public string available { get; set; }
			public string returned { get; set; }
			public string collectionURI { get; set; }
			public List<Item4> items { get; set; }
		}

		public class Result {
			public string id { get; set; }
			public string digitalId { get; set; }
			public string title { get; set; }
			public string issueNumber { get; set; }
			public string variantDescription { get; set; }
			public string description { get; set; }
			public string modified { get; set; }
			public string isbn { get; set; }
			public string upc { get; set; }
			public string diamondCode { get; set; }
			public string ean { get; set; }
			public string issn { get; set; }
			public string format { get; set; }
			public string pageCount { get; set; }
			public List<TextObject> textObjects { get; set; }
			public string resourceURI { get; set; }
			public List<Url> urls { get; set; }
			public Series series { get; set; }
			public List<Variant> variants { get; set; }
			public List<Collection> collections { get; set; }
			public List<CollectedIssue> collectedIssues { get; set; }
			public List<Date> dates { get; set; }
			public List<Price> prices { get; set; }
			public Thumbnail thumbnail { get; set; }
			public List<Image> images { get; set; }
			public Creators creators { get; set; }
			public Characters characters { get; set; }
			public Stories stories { get; set; }
			public Events events { get; set; }
		}

		public class Data {
			public string offset { get; set; }
			public string limit { get; set; }
			public string total { get; set; }
			public string count { get; set; }
			public List<Result> results { get; set; }
		}

		public class RootObject {
			public string code { get; set; }
			public string status { get; set; }
			public string copyright { get; set; }
			public string attributionText { get; set; }
			public string attributionHTML { get; set; }
			public Data data { get; set; }
			public string etag { get; set; }
		}
	}
}
