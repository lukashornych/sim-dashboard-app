using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace dashboardapp.data_classes
{
    public partial class DrDataClass : INotifyPropertyChanged
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

        private float _Speed;
        private float _Rpm;
        private float _MaxRpm;
        private int _Gear;

        public float Speed
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

        public float Rpm
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

        public float MaxRpm
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

        /// <summary>
        /// Map data from struct from memory to organized data class
        /// </summary>
        /// <param name="drDataStruct">Struct with raw data</param>
        /// <param name="drData">Data class to map raw data</param>
        /// <returns>Data class</returns>
        public DrDataClass MapStructToData(raw_data.DrDataStruct drDataStruct, DrDataClass drData)
        {
            drData.Speed = (float)Math.Round(drDataStruct.Speed * 3.6f);
            drData.Rpm = (float)Math.Round(drDataStruct.EngineRevs * 10);
            drData.MaxRpm = drDataStruct.MaxRpm;
            drData.Gear = (int)drDataStruct.Gear;

            return drData;
        }
    }
}
