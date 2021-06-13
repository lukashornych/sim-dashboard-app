using System.Windows;

namespace dashboardapp
{
    /// <summary>
    /// Interaction logic for pCarsInfoWindow.xaml
    /// </summary>
    public partial class DrInfoWindow : Window
    {
        public DrInfoWindow(data_classes.DrDataClass drData)
        {
            InitializeComponent();
            this.DataContext = drData;
        }
    }
}
