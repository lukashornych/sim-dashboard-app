using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace dashboardapp.data_readers
{
    public class PcarsReadMemoryData
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
                memoryMappedFile = MemoryMappedFile.OpenExisting("$pcars$");
                sharedMemorySize = Marshal.SizeOf(typeof(raw_data.PcarsDataStruct));
                sharedMemoryReadBuffer = new byte[sharedMemorySize];

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Read MMF
        /// </summary>
        /// <returns>Struct with data</returns>
        public Tuple<bool, raw_data.PcarsDataStruct> ReadSharedMemoryData()
        {
            raw_data.PcarsDataStruct _Struct = new raw_data.PcarsDataStruct();

            try
            {
                if (memoryMappedFile == null)
                    InitialiseSharedMemory();

                using (var sharedMemoryStreamView = memoryMappedFile.CreateViewStream())
                {
                    BinaryReader _SharedMemoryStream = new BinaryReader(sharedMemoryStreamView);
                    sharedMemoryReadBuffer = _SharedMemoryStream.ReadBytes(sharedMemorySize);
                    handle = GCHandle.Alloc(sharedMemoryReadBuffer, GCHandleType.Pinned);
                    _Struct = (raw_data.PcarsDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(raw_data.PcarsDataStruct));
                    handle.Free();
                }

                return new Tuple<bool, raw_data.PcarsDataStruct>(true, _Struct); //vrátí přečtená data
            }
            catch(Exception ex)
            {
                return new Tuple<bool, raw_data.PcarsDataStruct>(false, _Struct); //vrátí false, protože se čtení nezdařilo
            }
        }
    }
}
