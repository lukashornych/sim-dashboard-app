using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;

namespace dashboardapp
{
    public partial class MainWindow : Window
    {
        private data_readers.DataManager dataManager;
        private DispatcherTimer timer;
        private int refreshFrequency;
        private int testRefreshFrequency;
        private string selectedGame;

        private data_classes.AcDataClass acData;
        private data_classes.AtsDataClass atsData;
        private data_classes.PcarsDataClass pCarsData;
        private data_classes.TestDataClass testData;

        private device.DeviceManager deviceManager;
        private device.Device device;

        private info_panels.InfoPanelsManager infoPanelsManager;
        

        public MainWindow()
        {
            InitializeComponent();

            deviceManager = new device.DeviceManager();
            DataContext = deviceManager;

            acData = new data_classes.AcDataClass();
            atsData = new data_classes.AtsDataClass();
            pCarsData = new data_classes.PcarsDataClass();
            testData = new data_classes.TestDataClass();

            deviceManager.Devices = deviceManager.GetDevices();
            refreshFrequency = 10;
            testRefreshFrequency = 500;

            infoPanelsManager = new info_panels.InfoPanelsManager(acData, atsData, pCarsData, testData);
        }

        /// <summary>
        /// Stop everything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(device != null)
            {
                device.SendData(deviceManager.GetByteArrayReset());
                device.StopCommunicate();
            }

            if(dataManager != null)
                dataManager.StopReading();

            infoPanelsManager.CloseInfoPanels();
        }

        /*------------- Buttons actions -----------------*/

        /// <summary>
        /// Start getting and seding data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (deviceManager.AreDevices())
            {
                device = new device.Device(selectDeviceComboBox.SelectedItem.ToString());
                device.StartCommunicate();
            }

            timer = new DispatcherTimer();
            dataManager = new data_readers.DataManager(selectedGame, timer, refreshFrequency, testRefreshFrequency, device, acData, atsData, pCarsData, testData);
            timer.Tick += dataManager.ReadData;
            dataManager.StartReading();            

            startButton.IsEnabled = false;
            stopButton.IsEnabled = true;
            deviceSelectStackPanel.IsEnabled = false;
            gameSelectStackPanel.IsEnabled = false;
        }

        /// <summary>
        /// Stop everything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if(device != null)
            {
                device.SendData(deviceManager.GetByteArrayReset());
                device.StopCommunicate();
                device = null;
            }

            dataManager.StopReading();

            stopButton.IsEnabled = false;
            startButton.IsEnabled = true;
            deviceSelectStackPanel.IsEnabled = true;
            gameSelectStackPanel.IsEnabled = true;
        }

        /// <summary>
        /// Show readed data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            infoPanelsManager.OpenInfoPanel(selectedGame);
        }

        /// <summary>
        /// Load connected devices again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadDevicesButton_Click(object sender, RoutedEventArgs e)
        {
            deviceManager.Devices = deviceManager.GetDevices();
        }

        /// <summary>
        /// Get selected game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            selectedGame = rb.Uid;
        }
    }
}
