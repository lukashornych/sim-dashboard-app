using System.Windows;

namespace dashboardapp
{
    /// <summary>
    /// Interaction logic for pCarsInfoWindow.xaml
    /// </summary>
    public partial class AtsInfoWindow : Window
    {
        public AtsInfoWindow(data_classes.AtsDataClass atsData)
        {
            InitializeComponent();
            this.DataContext = atsData;
        }
    }
}
