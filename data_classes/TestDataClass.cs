using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace dashboardapp.data_classes
{
    public partial class TestDataClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string name = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        private int _Speed;
        private int _Rpm;
        private int _MaxRpm;
        private int _Gear;
        private int _Blinkers;
        private int _Test;

        public int Speed
        {
            get
            {
                return _Speed;
            }
            set
            {
                if (_Speed == value)
                    return;
                SetProperty(ref _Speed, value);
            }
        }

        public int Rpm
        {
            get
            {
                return _Rpm;
            }
            set
            {
                if (_Rpm == value)
                    return;
                SetProperty(ref _Rpm, value);
            }
        }

        public int MaxRpm
        {
            get
            {
                return _MaxRpm;
            }
            set
            {
                if (_MaxRpm == value)
                    return;
                SetProperty(ref _MaxRpm, value);
            }
        }

        public int Gear
        {
            get
            {
                return _Gear;
            }
            set
            {
                if (_Gear == value)
                    return;
                SetProperty(ref _Gear, value);
            }
        }

        public int Test
        {
            get
            {
                return _Test;
            }
            set
            {
                if (_Test == value)
                    return;
                SetProperty(ref _Test, value);
            }
        }

        public int Blinkers
        {
            get
            {
                return _Blinkers;
            }
            set
            {
                if (_Blinkers == value)
                    return;
                SetProperty(ref _Blinkers, value);
            }
        }

        /// <summary>
        /// Map data from struct from memory to organized data class
        /// </summary>
        /// <param name="testDataGenerator">Generator of test data</param>
        /// <param name="testData">Data class to map raw data</param>
        /// <returns>Data class</returns>
        public TestDataClass AssignToData(data_readers.TestDataGenerator testDataGenerator, TestDataClass testData)
        {
            testData.Speed = testDataGenerator.Speed;
            testData.Rpm = testDataGenerator.Rpm;
            testData.MaxRpm = 10000;
            testData.Gear = testDataGenerator.Gear;
            testData.Blinkers = testDataGenerator.Blinkers;
            testData.Test = testDataGenerator.Test;

            return testData;
        }
    }
}
