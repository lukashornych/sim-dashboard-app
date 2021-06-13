using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace dashboardapp.data_readers
{
    public class AtsReadMemoryData
    {
        private MemoryMappedFile memoryMappedFile;
        private GCHandle handle;
        private int sharedMemorySize;
        private byte[] sharedMemoryReadBuffer;

        /// <summary>
        /// Open MMF, get size of MMF
        /// </summary>
        /// <returns>Success</returns>
        private bool InitialiseSharedMemory()
        {
            try
            {
                memoryMappedFile = MemoryMappedFile.OpenExisting("Local\\Ets2TelemetryServer");
                sharedMemorySize = Marshal.SizeOf(typeof(raw_data.AtsDataStruct)); 
                sharedMemoryReadBuffer = new byte[sharedMemorySize];

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Read MMF
        /// </summary>
        /// <returns>Struct with data</returns>
        public Tuple<bool, raw_data.AtsDataStruct> ReadSharedMemoryData()
        {
            raw_data.AtsDataStruct _Struct = new raw_data.AtsDataStruct();

            try
            {
                if (memoryMappedFile == null)
                    InitialiseSharedMemory();

                using (var sharedMemoryStreamView = memoryMappedFile.CreateViewStream())
                {
                    BinaryReader _SharedMemoryStream = new BinaryReader(sharedMemoryStreamView);
                    sharedMemoryReadBuffer = _SharedMemoryStream.ReadBytes(sharedMemorySize);
                    handle = GCHandle.Alloc(sharedMemoryReadBuffer, GCHandleType.Pinned);
                    _Struct = (raw_data.AtsDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(raw_data.AtsDataStruct));
                    handle.Free();
                }

                return new Tuple<bool, raw_data.AtsDataStruct>(true, _Struct);
            }
            catch (Exception ex)
            {
                return new Tuple<bool, raw_data.AtsDataStruct>(false, _Struct);
            }
        }
    }
}
