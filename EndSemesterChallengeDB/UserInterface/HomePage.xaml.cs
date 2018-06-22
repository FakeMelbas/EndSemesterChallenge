using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using UserInterface.Models;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        HttpClient client = new HttpClient();

        UserInterface.MainWindow.API api = new UserInterface.MainWindow.API();

        TourEventsModel tourEvents1 = new TourEventsModel();

        public HomePage()
        {


            //tourEvents1.TourName = 
            InitializeComponent();
            GetData();

        }
        private async void GetData()
        {
            var content = await api.GetData("TourEventView?TourName=" + $"{MainWindow._TourEvents.TourName}");

            tourEvents1 = JsonConvert.DeserializeObject<TourEventsModel>(TourDG.ItemsSource.ToString());

            TourDG.ItemsSource = tourEvents1.TourName;


        }
    }
}
