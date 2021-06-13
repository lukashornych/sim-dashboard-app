using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace dashboardapp.data_readers
{
    public class DrReadUDPData
    {
        private int port = 20777;
        private UdpClient udpClient;
        private IPEndPoint endPoint;
        private byte[] byteArray;
        private GCHandle handle;

        public Tuple<bool, raw_data.DrDataStruct> ReadUDPData()
        {
            udpClient = new UdpClient(port);
            endPoint = new IPEndPoint(IPAddress.Any, port);
            raw_data.DrDataStruct _Struct = new raw_data.DrDataStruct();

            try
            {
                    byteArray = udpClient.Receive(ref endPoint);

                    handle = GCHandle.Alloc(byteArray, GCHandleType.Pinned);
                    _Struct = (raw_data.DrDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(raw_data.DrDataStruct));
                    handle.Free();

                return new Tuple<bool, raw_data.DrDataStruct>(true, _Struct);
            }
            catch(Exception e)
            {
                return new Tuple<bool, raw_data.DrDataStruct>(false, _Struct);
            }
            finally
            {
                udpClient.Close();
            }
        }
    }
}
