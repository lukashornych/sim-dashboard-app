using System.Windows;

namespace dashboardapp
{
    /// <summary>
    /// Interaction logic for pCarsInfoWindow.xaml
    /// </summary>
    public partial class TestInfoWindow : Window
    {
        public TestInfoWindow(data_classes.TestDataClass testData)
        {
            InitializeComponent();
            this.DataContext = testData;
        }
    }
}
