using System;
using System.IO.Ports;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace dashboardapp.device
{
    public class DeviceManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] String propertyName = "")
        {
            if(!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<string> _Devices;
        private string _SelectedDevice;

        /// <summary>
        /// Store connected devices to pc
        /// </summary>
        public ObservableCollection<string> Devices
        {
            get
            {
                return _Devices;
            }

            set
            {
                if (_Devices == value)
                    return;
                SetProperty(ref _Devices, value);

                if (AreDevices())
                    SelectedDevice = Devices[0];
            }
        }

        /// <summary>
        /// Selected device
        /// </summary>
        public string SelectedDevice
        {
            get
            {
                return _SelectedDevice;
            }

            set
            {
                if (_SelectedDevice == value)
                    return;
                SetProperty(ref _SelectedDevice, value);
            }
        }

        public DeviceManager()
        {
            _Devices = new ObservableCollection<string>();
        }

        /// <summary>
        /// Get all devices connected to COM
        /// </summary>
        /// <returns>Devices names</returns>
        public ObservableCollection<string> GetDevices()
        {
            ObservableCollection<string> _devices = new ObservableCollection<string>();

            foreach(string d in SerialPort.GetPortNames())
            {
                _devices.Add(d);
            }

            return _devices;
        }

        /// <summary>
        /// Check if any devices are connected
        /// </summary>
        /// <returns>If any devices are connected</returns>
        public bool AreDevices()
        {
            return Devices.Count != 0;
        }

        /// <summary>
        /// Create data array for ProjectCars
        /// </summary>
        /// <param name="pCarsData">Current data from ProjectCars</param>
        /// <returns>Data to send</returns>
        public byte[] GetByteArrayPCars(data_classes.PcarsDataClass pCarsData)
        {
            /*
             * LIST OF BYTES IN ARRAY
             * 2 bytes of speed
             * 2 bytes of Rpm
             * 1 byte of max rpm
             * 1 byte of gear
             * 1 byte of fuel warning
             */

            byte[] byteArray = new byte[11];
            byte[] tempArray;

            byteArray[0] = BitConverter.GetBytes('R')[0];

            tempArray = BitConverter.GetBytes((Int16)pCarsData.Speed);
            byteArray[1] = tempArray[0];
            byteArray[2] = tempArray[1];

            tempArray = BitConverter.GetBytes((Int16)pCarsData.Rpm);
            byteArray[3] = tempArray[0];
            byteArray[4] = tempArray[1];

            byteArray[5] = BitConverter.GetBytes((Int16)(pCarsData.MaxRpm / 100))[0];
            byteArray[6] = BitConverter.GetBytes((Int16)pCarsData.Gear)[0];
            byteArray[7] = (pCarsData.Fuel <= 6.0) ? BitConverter.GetBytes(1)[0] : BitConverter.GetBytes(0)[0];

            tempArray = BitConverter.GetBytes(0);
            byteArray[8] = tempArray[0];
            byteArray[9] = tempArray[0];
            byteArray[10] = tempArray[0];

            return byteArray;
        }

        /// <summary>
        /// Create data array for Assetto Corsa
        /// </summary>
        /// <param name="acData">Current data from Assetto Corsa</param>
        /// <returns>Data to send</returns>
        public byte[] GetByteArrayAC(data_classes.AcDataClass acData)
        {
            /*
             * LIST OF BYTES IN ARRAY
             * 2 bytes of speed
             * 2 bytes of rpm
             * 1 byte of max rpm
             * 1 byte of gear
             * 1 byte of fuel warning
             */

            byte[] byteArray = new byte[11];
            byte[] tempArray;

            byteArray[0] = BitConverter.GetBytes('R')[0];

            tempArray = BitConverter.GetBytes((Int16)acData.Speed);
            byteArray[1] = tempArray[0];
            byteArray[2] = tempArray[1];

            tempArray = BitConverter.GetBytes((Int16)acData.Rpm);
            byteArray[3] = tempArray[0];
            byteArray[4] = tempArray[1];

            byteArray[5] = BitConverter.GetBytes((Int16)(acData.MaxRpm / 100))[0];

            byteArray[6] = BitConverter.GetBytes((Int16)acData.Gear)[0];

            byteArray[7] = BitConverter.GetBytes(0)[0];

            tempArray = BitConverter.GetBytes(0);
            byteArray[8] = tempArray[0];
            byteArray[9] = tempArray[0];
            byteArray[10] = tempArray[0];

            return byteArray;
        }

        /// <summary>
        /// Create data array for American Truck Simulator/Euro Truck Simulator 2
        /// </summary>
        /// <param name="atsData">Current data from ATS/ETS2</param>
        /// <returns>Data to send</returns>
        public byte[] GetByteArrayATS(data_classes.AtsDataClass atsData)
        {
            /*
             * LIST OF BYTES IN ARRAY
             * 1 byte of speed
             * 1 byte of speed limit
             * 2 bytes of rpm
             * 1 byte of max rpm
             * 1 byte of gear
             * 1 byte of fuel warning
             * 1 byte of cruise control
             * 1 byte of blinkers on
             * 1 byte of rest stop
             * 1 byte of wear trailer
             */

            byte[] byteArray = new byte[11];
            byte[] tempArray;

            byteArray[0] = BitConverter.GetBytes('A')[0];
            byteArray[1] = BitConverter.GetBytes((Int16)atsData.Speed)[0];
            byteArray[2] = BitConverter.GetBytes((Int16)atsData.SpeedLimit)[0];

            tempArray = BitConverter.GetBytes((Int16)atsData.Rpm);
            byteArray[3] = tempArray[0];
            byteArray[4] = tempArray[1];

            byteArray[5] = BitConverter.GetBytes((Int16)(atsData.MaxRpm / 100))[0];
            byteArray[6] = BitConverter.GetBytes((Int16)atsData.Gear)[0];
            byteArray[7] = BitConverter.GetBytes((Int16)atsData.FuelWarning)[0];
            byteArray[8] = BitConverter.GetBytes((Int16)atsData.CruiseControl)[0];
            byteArray[9] = BitConverter.GetBytes((Int16)(atsData.BlinkerLeftOn + (atsData.BlinkerRightOn * 2)))[0];
            byteArray[10] = BitConverter.GetBytes((Int16)atsData.RestStopNeed)[0];

            return byteArray;
        }

        /// <summary>
        /// Create data array for device testing purposes
        /// </summary>
        /// <param name="testData">Current data from generator</param>
        /// <returns>Data to send</returns>
        public byte[] GetByteArrayTest(data_classes.TestDataClass testData)
        {
            /*
             * LIST OF BYTES IN ARRAY
             * 2 bytes of speed
             * 2 bytes of rpm
             * 1 byte of max rpm
             * 1 byte of gear
             * 1 byte of blinkers
             * 1 byte of 0 or 1
             * 1 byte of 0 or 1
             * 1 byte of 0 or 1
             */

            byte[] byteArray = new byte[11];
            byte[] tempArray;

            byteArray[0] = BitConverter.GetBytes('T')[0];

            tempArray = BitConverter.GetBytes(testData.Speed);
            byteArray[1] = tempArray[0];
            byteArray[2] = tempArray[1];

            tempArray = BitConverter.GetBytes(testData.Rpm);
            byteArray[3] = tempArray[0];
            byteArray[4] = tempArray[1];

            byteArray[5] = BitConverter.GetBytes((Int16)(testData.MaxRpm / 100))[0];
            byteArray[6] = BitConverter.GetBytes(testData.Gear)[0];
            byteArray[7] = BitConverter.GetBytes(testData.Blinkers)[0];
            byteArray[8] = BitConverter.GetBytes(testData.Test)[0];

            tempArray = BitConverter.GetBytes(0);
            byteArray[9] = tempArray[0];
            byteArray[10] = tempArray[0];

            return byteArray;
        }

        /// <summary>
        /// Create data array to reset device
        /// </summary>
        /// <returns>Data to send</returns>
        public byte[] GetByteArrayReset()
        {
            byte[] byteArray = new byte[11];
            byte[] tempArray;

            byteArray[0] = BitConverter.GetBytes('E')[0];

            tempArray = BitConverter.GetBytes(0);

            for (int i = 1; i <= 10; i++)
            {
                byteArray[i] = tempArray[0];
            }

            return byteArray;
        }
    }
}
