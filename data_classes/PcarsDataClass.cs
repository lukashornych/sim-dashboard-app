using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace dashboardapp.data_classes
{
    public partial class PcarsDataClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string name = "")
        {
            if(!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        private float _FuelLevel;
        private float _FuelCapacity;
        private float _Fuel;
        private float _Speed;               //meters per second
        private float _Rpm;
        private float _MaxRpm;
        private int _Gear;                  //-1 = r / 0 = n / 1...

        public float FuelLevel
        {
            get
            {
                return _FuelLevel;
            }
            set
            {
                if (_FuelLevel == value)
                    return;
                SetProperty(ref _FuelLevel, value);
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
        /// <param name="pCarsDataStruct">Struct with raw data</param>
        /// <param name="pCarsData">Data class to map raw data</param>
        /// <returns>Data class</returns>
        public PcarsDataClass MapStructToData(raw_data.PcarsDataStruct pCarsDataStruct, PcarsDataClass pCarsData)
        {
            pCarsData.FuelLevel = pCarsDataStruct.mFuelLevel;
            pCarsData.FuelCapacity = pCarsDataStruct.mFuelCapacity;
            pCarsData.Fuel = (float)Math.Round(pCarsDataStruct.mFuelLevel * pCarsDataStruct.mFuelCapacity, 1);
            pCarsData.Speed = (float)Math.Round(pCarsDataStruct.mSpeed * 3.6f);
            pCarsData.Rpm = ((float)Math.Round(pCarsDataStruct.mRpm / 100)) * 100;
            pCarsData.MaxRpm = pCarsDataStruct.mMaxRpm;
            pCarsData.Gear = pCarsDataStruct.mGear;

            return pCarsData;
        }

    }
}
