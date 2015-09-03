using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using RestSharp;
using RestSharp.Deserializers;
using System.Security.Cryptography;

namespace MarvelComicCalanderUpdater {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

		List<Comics.Result> comicList;
		
		MarvelApi marvelApi;

        public MainWindow() {
            InitializeComponent();
			marvelApi = new MarvelApi();
        }

		private void SearchButton_Click(object sender, RoutedEventArgs e) {
			comicList = marvelApi.searchComics(searchBox.Text);
			listBox.ItemsSource = comicList;
			listBox.DisplayMemberPath = "title";
		}

		private void AddButton_Click(object sender, RoutedEventArgs e) {
			Comics.Result comic = (Comics.Result)listBox.SelectedItem;
			GoogleCalender calender = new GoogleCalender();
			calender.CreateEvent(listBox.Text, comic.dates[0].date);
		}

        private void AddAllButton_Click(object sender, RoutedEventArgs e) {
            GoogleCalender calender = new GoogleCalender();
            foreach (Comics.Result comic in listBox.ItemsSource) {
                if (Convert.ToDateTime(comic.dates[0].date) > DateTime.Now){
                    calender.CreateEvent(comic.title, comic.dates[0].date);
                }
            }
        }

    }
}

