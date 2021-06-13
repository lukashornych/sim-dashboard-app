using System.Windows;

namespace dashboardapp
{
    /// <summary>
    /// Interaction logic for pCarsInfoWindow.xaml
    /// </summary>
    public partial class PcarsInfoWindow : Window
    {
        public PcarsInfoWindow(data_classes.PcarsDataClass pCarsData)
        {
            InitializeComponent();
            this.DataContext = pCarsData;
        }
    }
}
