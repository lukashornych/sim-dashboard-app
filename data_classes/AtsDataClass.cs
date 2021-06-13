using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace dashboardapp.data_classes
{
    public partial class AtsDataClass : INotifyPropertyChanged
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

        private float _Speed;
        private float _SpeedLimit;
        private int _Gear;
        private float _Rpm;
        private float _MaxRpm;
        private byte _CruiseControl;
        private byte _BlinkerLeftOn;
        private byte _BlinkerRightOn;
        private int _FuelWarning;
        private float _WearTrailer;
        private int _RestStopNeed;

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

        public float SpeedLimit
        {
            get
            {
                return _SpeedLimit;
            }
            set
            {
                if (_SpeedLimit == value)
                    return;
                SetProperty(ref _SpeedLimit, value);
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

        public byte CruiseControl
        {
            get
            {
                return _CruiseControl;
            }
            set
            {
                if (_CruiseControl == value)
                    return;
                SetProperty(ref _CruiseControl, value);
            }
        }

        public byte BlinkerLeftOn
        {
            get
            {
                return _BlinkerLeftOn;
            }
            set
            {
                if (_BlinkerLeftOn == value)
                    return;
                SetProperty(ref _BlinkerLeftOn, value);
            }
        }

        public byte BlinkerRightOn
        {
            get
            {
                return _BlinkerRightOn;
            }
            set
            {
                if (_BlinkerRightOn == value)
                    return;
                SetProperty(ref _BlinkerRightOn, value);
            }
        }

        public int FuelWarning
        {
            get
            {
                return _FuelWarning;
            }
            set
            {
                if (_FuelWarning == value)
                    return;
                SetProperty(ref _FuelWarning, value);
            }
        }

        public float WearTrailer
        {
            get
            {
                return _WearTrailer;
            }
            set
            {
                if (_WearTrailer == value)
                    return;
                SetProperty(ref _WearTrailer, value);
            }
        }

        public int RestStopNeed
        {
            get
            {
                return _RestStopNeed;
            }
            set
            {
                if (_RestStopNeed == value)
                    return;
                SetProperty(ref _RestStopNeed, value);
            }
        }

        /// <summary>
        /// Map data from struct from memory to organized data class
        /// </summary>
        /// <param name="atsDataStruct">Struct with raw data</param>
        /// <param name="atsData">Data class to map raw data</param>
        /// <returns>Data class</returns>
        public AtsDataClass MapStructToData(raw_data.AtsDataStruct atsDataStruct, AtsDataClass atsData)
        {
            atsData.Speed = Math.Abs((float)Math.Round(atsDataStruct.speed * 3.6f));
            atsData.SpeedLimit = ((((float)Math.Round(atsDataStruct.navigationSpeedLimit * 3.6f)) < atsData.Speed) && (((float)Math.Round(atsDataStruct.navigationSpeedLimit * 3.6f)) != 0)) ? 1 : 0;
            atsData.Gear = atsDataStruct.gear;
            atsData.Rpm = ((float)Math.Round(atsDataStruct.engineRpm / 100)) * 100;
            atsData.MaxRpm = (float)Math.Round(atsDataStruct.engineRpmMax);
            atsData.CruiseControl = atsDataStruct.cruiseControl;
            atsData.BlinkerLeftOn = atsDataStruct.blinkerLeftOn;
            atsData.BlinkerRightOn = atsDataStruct.blinkerRightOn;
            atsData.FuelWarning = (atsDataStruct.fuel < (atsDataStruct.fuelCapacity * 0.25)) ? 1 : 0;
            atsData.WearTrailer = ((Math.Round(atsDataStruct.wearTrailer) * 100) >= 2) ? 1 : 0;
            atsData.RestStopNeed = (atsDataStruct.nextRestStop <= 400) ? 1 : 0;

            return atsData;
        }
    }
}
