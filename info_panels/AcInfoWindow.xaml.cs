using System.Windows;

namespace dashboardapp
{
    /// <summary>
    /// Interaction logic for pCarsInfoWindow.xaml
    /// </summary>
    public partial class AcInfoWindow : Window
    {
        public AcInfoWindow(data_classes.AcDataClass acData)
        {
            InitializeComponent();
            this.DataContext = acData;
        }
    }
}
