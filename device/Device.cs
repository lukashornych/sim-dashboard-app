using System.IO.Ports;
using System.Windows;
using System;

namespace dashboardapp.device
{
    public class Device
    {
        private SerialPort serialPort;
        private bool serialPortInitialised = false;

        /// <summary>
        /// Set up serial port for Arduino
        /// </summary>
        /// <param name="device"></param>
        public Device(string device)
        {
            //vytvoří a nastaví zařízení
            serialPort = new SerialPort()
            {
                PortName = device,
                BaudRate = 115200,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                RtsEnable = true,
                WriteTimeout = 100
            };

            serialPortInitialised = true;
        }

        /// <summary>
        /// Start communicate between device and pc
        /// </summary>
        public void StartCommunicate()
        {
            if(serialPortInitialised)
                serialPort.Open();
        }

        /// <summary>
        /// Stop communication
        /// </summary>
        public void StopCommunicate()
        {
            if(serialPortInitialised)
                serialPort.Close();
        }

        /// <summary>
        /// Send array of data to device
        /// </summary>
        /// <param name="byteArray">Data to send</param>
        public void SendData(byte[] byteArray)
        {
            if (serialPortInitialised)
            {
                try
                {
                    serialPort.Write(byteArray, 0, byteArray.Length);
                }
                catch(Exception ex)
                {
                    StopCommunicate();
                }
            }
        }
    }
}
