using System;
using System.Windows.Threading;
using System.Windows;

namespace dashboardapp.data_readers
{
    public class DataManager
    {
        private string selectedGame;
        private DispatcherTimer timer;
        private int refreshFrequency;
        private int testRefreshFrequency;
        private device.Device device;
        private device.DeviceManager deviceManager;

        private AcReadMemoryData acReader;
        private AtsReadMemoryData atsReader;
        private PcarsReadMemoryData pCarsReader;
        private TestDataGenerator testGenerator;

        private data_classes.AcDataClass acData;
        private data_classes.AtsDataClass atsData;
        private data_classes.PcarsDataClass pCarsData;
        private data_classes.TestDataClass testData;

        /// <summary>
        /// Initialize DataManager
        /// </summary>
        /// <param name="selectedGame">Selected game id</param>
        /// <param name="refreshFrequency">Data sending frequency</param>
        /// <param name="testRefreshFrequency">Test data sending frequency</param>
        /// <param name="device">Device to send data to</param>
        public DataManager(string selectedGame, DispatcherTimer timer, int refreshFrequency, int testRefreshFrequency, device.Device device, data_classes.AcDataClass acData, data_classes.AtsDataClass atsData, data_classes.PcarsDataClass pCarsData, data_classes.TestDataClass testData)
        {
            this.selectedGame = selectedGame;
            this.timer = timer;
            this.refreshFrequency = refreshFrequency;
            this.testRefreshFrequency = testRefreshFrequency;
            this.device = device;
            this.acData = acData;
            this.atsData = atsData;
            this.pCarsData = pCarsData;
            this.testData = testData;

            acReader = new AcReadMemoryData();
            atsReader = new AtsReadMemoryData();
            pCarsReader = new PcarsReadMemoryData();
            testGenerator = new TestDataGenerator();

            deviceManager = new device.DeviceManager();
        }

        /// <summary>
        /// Start reading data from game
        /// </summary>
        public void StartReading()
        {
            timer.Interval = TimeSpan.FromMilliseconds((selectedGame == "test") ? testRefreshFrequency : refreshFrequency);
            timer.Start();
        }

        /// <summary>
        /// Stop reading data from game
        /// </summary>
        public void StopReading()
        {
            timer.Stop();
        }

        /// <summary>
        /// Read data from game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReadData(object sender, EventArgs e)
        {
            switch (selectedGame)
            {
                case "ac":
                    ReadAc();
                    if (device != null)
                        device.SendData(deviceManager.GetByteArrayAC(acData));
                    break;
                case "ats":
                    ReadAts();
                    if (device != null)
                        device.SendData(deviceManager.GetByteArrayATS(atsData));
                    break;
                case "pcars":
                    ReadPcars();
                    if (device != null)
                        device.SendData(deviceManager.GetByteArrayPCars(pCarsData));
                    break;
                case "test":
                    ReadTest();
                    if (device != null)
                        device.SendData(deviceManager.GetByteArrayTest(testData));
                    break;
            }
        }

        /// <summary>
        /// Read data from AC
        /// </summary>
        private void ReadAc()
        {
            var returnPhysicsTuple = acReader.ReadPhysicsSharedMemoryData();
            var returnStaticTuple = acReader.ReadStaticSharedMemoryData();

            if (returnPhysicsTuple.Item1 && returnStaticTuple.Item1)
                acData = acData.MapStructToData(returnPhysicsTuple.Item2, returnStaticTuple.Item2, acData);
        }

        /// <summary>
        /// Read data from Ats/Ets2
        /// </summary>
        private void ReadAts()
        {
            var returnTuple = atsReader.ReadSharedMemoryData();

            if (returnTuple.Item1)
                atsData = atsData.MapStructToData(returnTuple.Item2, atsData);
        }

        /// <summary>
        /// Read data from pCars
        /// </summary>
        private void ReadPcars()
        {
            var returnTuple = pCarsReader.ReadSharedMemoryData();

            if (returnTuple.Item1)
                pCarsData = pCarsData.MapStructToData(returnTuple.Item2, pCarsData);
        }

        /// <summary>
        /// Read data from test generator
        /// </summary>
        private void ReadTest()
        {
            testGenerator.GenerateNextValues();

            testData = testData.AssignToData(testGenerator, testData);
        }
    }
}
