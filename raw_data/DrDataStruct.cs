using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dashboardapp.raw_data
{
    [Serializable]
    public struct DrDataStruct : ISerializable
    {
        public DrDataStruct(SerializationInfo info, StreamingContext context)
        {
            Time = (float)info.GetValue("Time", typeof(float));
            LapTime = (float)info.GetValue("LapTime", typeof(float));
            LapDistance = (float)info.GetValue("LapDistance", typeof(float));
            Distance = (float)info.GetValue("Distance", typeof(float));
            Speed = (float)info.GetValue("Speed", typeof(float));
            Lap = (float)info.GetValue("Lap", typeof(float));
            X = (float)info.GetValue("X", typeof(float));
            Y = (float)info.GetValue("Y", typeof(float));
            Z = (float)info.GetValue("Z", typeof(float));
            XV = 0;
            YV = 0;
            ZV = 0;
            XR = 0;
            YR = 0;
            ZR = 0;
            XD = 0;
            YD = 0;
            ZD = 0;
            SuspensionPositionRearLeft = 0;
            SuspensionPositionRearRight = 0;
            SuspensionPositionFrontLeft = 0;
            SuspensionPositionFrontRight = 0;
            SuspensionVelocitoyRearLeft = 0;
            SuspensionVelocitoyRearRight = 0;
            SuspensionVelocitoyFrontLeft = 0;
            SuspensionVelocitoyFrontRight = 0;
            WheelSpeedBackLeft = 0;
            WheelSpeedBackRight = 0;
            WheelSpeedFrontLeft = 0;
            WheelSpeedFrontRight = 0;
            Throttle = (float)info.GetValue("Throttle", typeof(float));
            Steer = 0;
            Brake = 0;
            Clutch = 0;
            Gear = (float)info.GetValue("Gear", typeof(float));
            GForceLatitudinal = 0;
            GForceLongitudinal = 0;
            EngineRevs = (float)info.GetValue("EngineRevs", typeof(float));
            MaxRpm = (float)info.GetValue("MaxRpm", typeof(float));

        }

        public float Time;
        public float LapTime;
        public float LapDistance;
        public float Distance;
        [XmlIgnore]
        public float X;
        [XmlIgnore]
        public float Y;
        [XmlIgnore]
        public float Z;
        public float Speed;
        [XmlIgnore]
        public float XV;
        [XmlIgnore]
        public float YV;
        [XmlIgnore]
        public float ZV;
        [XmlIgnore]
        public float XR;
        [XmlIgnore]
        public float YR;
        [XmlIgnore]
        public float ZR;
        [XmlIgnore]
        public float XD;
        [XmlIgnore]
        public float YD;
        [XmlIgnore]
        public float ZD;
        [XmlIgnore]
        public float SuspensionPositionRearLeft;
        [XmlIgnore]
        public float SuspensionPositionRearRight;
        [XmlIgnore]
        public float SuspensionPositionFrontLeft;
        [XmlIgnore]
        public float SuspensionPositionFrontRight;
        [XmlIgnore]
        public float SuspensionVelocitoyRearLeft;
        [XmlIgnore]
        public float SuspensionVelocitoyRearRight;
        [XmlIgnore]
        public float SuspensionVelocitoyFrontLeft;
        [XmlIgnore]
        public float SuspensionVelocitoyFrontRight;
        [XmlIgnore]
        public float WheelSpeedBackLeft;
        [XmlIgnore]
        public float WheelSpeedBackRight;
        [XmlIgnore]
        public float WheelSpeedFrontLeft;
        [XmlIgnore]
        public float WheelSpeedFrontRight;
        [XmlIgnore]
        public float Throttle;
        [XmlIgnore]
        public float Steer;
        [XmlIgnore]
        public float Brake;
        [XmlIgnore]
        public float Clutch;
        [XmlIgnore]
        public float Gear;
        [XmlIgnore]
        public float GForceLatitudinal;
        [XmlIgnore]
        public float GForceLongitudinal;
        public float Lap;
        [XmlIgnore]
        public float EngineRevs;
        [XmlIgnore]
        public float MaxRpm;

        public override string ToString()
        {
            return "Lap: " + Lap + ", " +
                   "Time: " + Time + ", " +
                   "LapTime: " + LapTime + ", " +
                   "LapDistance: " + LapDistance + ", " +
                   "Distance: " + Distance + ", " +
                   "Speed: " + Speed;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Time", Time);
            info.AddValue("LapTime", LapTime);
            info.AddValue("LapDistance", LapDistance);
            info.AddValue("Distance", Distance);
            info.AddValue("Speed", Speed);
            info.AddValue("Lap", Lap);
            info.AddValue("Gear", Gear);
            info.AddValue("EngineRevs", EngineRevs);
        }
        /*
        public float m_time;
        public float m_lapTime;
        public float m_lapDistance;
        public float m_totalDistance;
        public float m_x;      // World space position
        public float m_y;      // World space position
        public float m_z;      // World space position
        public float m_speed;
        public float m_xv;      // Velocity in world space
        public float m_yv;      // Velocity in world space
        public float m_zv;      // Velocity in world space
        public float m_xr;      // World space right direction
        public float m_yr;      // World space right direction
        public float m_zr;      // World space right direction
        public float m_xd;      // World space forward direction
        public float m_yd;      // World space forward direction
        public float m_zd;      // World space forward direction
        public float m_susp_pos_bl;
        public float m_susp_pos_br;
        public float m_susp_pos_fl;
        public float m_susp_pos_fr;
        public float m_susp_vel_bl;
        public float m_susp_vel_br;
        public float m_susp_vel_fl;
        public float m_susp_vel_fr;
        public float m_wheel_speed_bl;
        public float m_wheel_speed_br;
        public float m_wheel_speed_fl;
        public float m_wheel_speed_fr;
        public float m_throttle;
        public float m_steer;
        public float m_brake;
        public float m_clutch;
        public float m_gear;
        public float m_gforce_lat;
        public float m_gforce_lon;
        public float m_lap;
        public float m_engineRate;
        public float m_sli_pro_native_support; // SLI Pro support
        public float m_car_position;   // car race position
        public float m_kers_level;    // kers energy left
        public float m_kers_max_level;   // kers maximum energy
        public float m_drs;     // 0 = off, 1 = on
        public float m_traction_control;  // 0 (off) - 2 (high)
        public float m_anti_lock_brakes;  // 0 (off) - 1 (on)
        public float m_fuel_in_tank;   // current fuel mass
        public float m_fuel_capacity;   // fuel capacity
        public float m_in_pits;    // 0 = none, 1 = pitting, 2 = in pit area
        public float m_sector;     // 0 = sector1, 1 = sector2; 2 = sector3
        public float m_sector1_time;   // time of sector1 (or 0)
        public float m_sector2_time;   // time of sector2 (or 0)
        public float[] m_brakes_temp;   // brakes temperature (centigrade)
        public float[] m_wheels_pressure;  // wheels pressure PSI
        public float m_team_info;    // team ID 
        public float m_total_laps;    // total number of laps in this race
        public float m_track_size;    // track size meters
        public float m_last_lap_time;   // last lap time
        public float m_max_rpm;    // cars max RPM, at which point the rev limiter will kick in
        public float m_idle_rpm;    // cars idle RPM
        public float m_max_gears;    // maximum number of gears
        public float m_sessionType;   // 0 = unknown, 1 = practice, 2 = qualifying, 3 = race
        public float m_drsAllowed;    // 0 = not allowed, 1 = allowed, -1 = invalid / unknown
        public float m_track_number;   // -1 for unknown, 0-21 for tracks
        public float m_vehicleFIAFlags;  // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
        */
    }
}
