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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public class API
        {
            HttpClient client = new HttpClient();

            public async Task<string> GetData(string url)
            {

                string uri = $"http://endsemesterchallenge.azurewebsites.net/api/" + $"{url}";

                client.BaseAddress = new Uri(uri);

                HttpResponseMessage httpResponseMessage = await client.GetAsync(uri);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                return content;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            NavigationCommands.BrowseBack.InputGestures.Clear();
            NavigationCommands.BrowseForward.InputGestures.Clear();
            ShowsNavigationUI = false;
        }
        public static TourEventsModel _TourEvents;
    }
}
