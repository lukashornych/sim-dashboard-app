using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace dashboardapp.data_classes
{
    public partial class AcDataClass : INotifyPropertyChanged
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
        private int _Rpm;
        private int _MaxRpm;
        private int _Gear;
        private float _FuelCapacity;
        private float _Fuel;

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

        public float FuelCapacity
        {
            get
            {
                return _FuelCapacity;
            }

            set
            {
                if (_FuelCapacity == value)
                    return;
                SetProperty(ref _FuelCapacity, value);
            }
        }

        public float Fuel
        {
            get
            {
                return _Fuel;
            }

            set
            {
                if (_Fuel == value)
                    return;
                SetProperty(ref _Fuel, value);
            }
        }

        /// <summary>
        /// Map data from struct from memory to organized data class
        /// </summary>
        /// <param name="acPhysicsDataStruct">Struct with raw data - physics data struct</param>
        /// <param name="acStaticDataStruct">Struct with raw data - statis data struct</param>
        /// <param name="acData">Data class to map raw data</param>
        /// <returns>Data class</returns>
        public AcDataClass MapStructToData(raw_data.AcPhysicsDataStruct acPhysicsDataStruct, raw_data.AcStaticDataStruct acStaticDataStruct, AcDataClass acData)
        {
            acData.Speed = (float)Math.Round(acPhysicsDataStruct.speedKmh);
            acData.Rpm = ((int)Math.Round((Decimal)acPhysicsDataStruct.rpms / 100)) * 100;
            acData.MaxRpm = acStaticDataStruct.maxRpm;
            acData.Gear = acPhysicsDataStruct.gear - 1;
            acData.FuelCapacity = (float)Math.Round(acStaticDataStruct.maxFuel);
            acData.Fuel = (float)Math.Round(acPhysicsDataStruct.fuel);

            return acData;
        }
    }
}
