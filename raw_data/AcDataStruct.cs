using System.Runtime.InteropServices;

namespace dashboardapp.raw_data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public struct AcPhysicsDataStruct
    {
        public int packetId;
        public float gas;
        public float brake;
        public float fuel;
        public int gear;
        public int rpms;
        public float steerAngle;
        public float speedKmh;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] velocity;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] accG;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] wheelSlip;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] wheelLoad;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] wheelsPressure;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] wheelAngularSpeed;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] tyreWear;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] tyreDirtyLevel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] tyreCoreTemperature;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] camberRAD;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] suspensionTravel;
        public float drs;
        public float tc;
        public float heading;
        public float pitch;
        public float roll;
        public float cgHeight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public float[] carDamage;
        public int numberOfTyresOut;
        public int pitLimiterOn;
        public float abs;
        public float kersCharge;
        public float kersInput;
        public int autoShifterOn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] rideHeight;
        public float turboBoost;
        public float ballast;
        public float airDensity;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public struct AcStaticDataStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string smVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string acVersion;
        // session static info
        public int numberOfSessions;
        public int numCars;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string carModel;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string track;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string playerName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string playerSurname;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string playerNick;
        public int sectorCount;

        // car static info
        public float maxTorque;
        public float maxPower;
        public int maxRpm;
        public float maxFuel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] suspensionMaxTravel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] tyreRadius;
        public float maxTurboBoost;

        public float airTemp;
        public float roadTemp;
        public bool penaltiesEnabled;

        public float aidFuelRate;
        public float aidTireRate;
        public float aidMechanicalDamage;
        public bool aidAllowTyreBlankets;
        public float aidStability;
        public bool aidAutoClutch;
        public bool aidAutoBlip;

        public int HasDRS;
        public int HasERS;
        public int HasKERS;
        public float KersMaxJoules;
        public int EngineBrakeSettingsCount;
        public int ErsPowerControllerCount;
        public float TrackSPlineLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string TrackConfiguration;

        public float ErsMaxJ;

        public int IsTimedRace;
        public int HasExtraLap;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string CarSkin;
        public int ReversedGridPositions;
        public int PitWindowStart;
        public int PitWindowEnd;
    }
}
