using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using CsharpOgDB3layer;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ShowAllPetsWindow.xaml
    /// </summary>
    public partial class ShowAllPetsWindow : Window, ISubscriber
    {
        Controller con;
        public ShowAllPetsWindow(Controller controller)
        {
            InitializeComponent();
            con = controller;
            con.RegisterSubscriber(this);
            BreakListDown();
        }

        private void PetInformationView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void BreakListDown()
        {
            List<string> PetData = con.GetAllPets();
            foreach (string item in PetData)
            {
                string[] arr = item.Split('/');
                this.PetInformationView.Items.Add(new Items
                {
                    PetID = arr[0],
                    PetName = arr[1],
                    PetType = arr[2],
                    PetBreed = arr[3],
                    PetDOB = arr[4],
                    PetWeight = arr[5],
                    OwnerID = arr[6]
                });
            }

        }

        public class Items
        {
            public string PetID { get; set; }
            public string PetName { get; set; }
            public string PetType { get; set; }
            public string PetBreed { get; set; }
            public string PetDOB { get; set; }
            public string PetWeight { get; set; }
            public string OwnerID { get; set; }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        public void Update(IPublisher publisher, string message)
        {
            string[] arr = message.Split(';');
            this.PetInformationView.Items.Add(new Items
            {
                PetName = arr[0],
                PetType = arr[1],
                PetBreed = arr[2],
                PetDOB = arr[3],
                PetWeight = arr[4],
                OwnerID = arr[5]
            });
        }
    }
}
