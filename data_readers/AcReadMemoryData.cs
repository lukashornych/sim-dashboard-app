using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace dashboardapp.data_readers
{
    public class AcReadMemoryData
    {
        private MemoryMappedFile memoryMappedFilePhysics;
        private MemoryMappedFile memoryMappedFile;
        private GCHandle handle;
        private int sharedMemorySizePhysics;
        private int sharedMemorySize;
        private byte[] sharedMemoryReadBufferPhysics;
        private byte[] sharedMemoryReadBuffer;

        /// <summary>
        /// Open MMF, get size of MMF - physics data
        /// </summary>
        /// <returns>Success</returns>
        public bool InitialisePhysicsSharedMemory()
        {
            try
            {
                memoryMappedFilePhysics = MemoryMappedFile.OpenExisting("Local\\acpmf_physics");
                sharedMemorySizePhysics = Marshal.SizeOf(typeof(raw_data.AcPhysicsDataStruct));
                sharedMemoryReadBufferPhysics = new byte[sharedMemorySizePhysics];

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Open MMF and get size of MMF - static data
        /// </summary>
        /// <returns>Success</returns>
        public bool InitialiseStaticSharedMemory()
        {
            try
            {
                memoryMappedFile = MemoryMappedFile.OpenExisting("Local\\acpmf_static");
                sharedMemorySize = Marshal.SizeOf(typeof(raw_data.AcStaticDataStruct));
                sharedMemoryReadBuffer = new byte[sharedMemorySize];

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Read MMF - physics data
        /// </summary>
        /// <returns>Struct with data</returns>
        public Tuple<bool, raw_data.AcPhysicsDataStruct> ReadPhysicsSharedMemoryData()
        {
            raw_data.AcPhysicsDataStruct _Struct = new raw_data.AcPhysicsDataStruct();

            try
            {
                if(memoryMappedFilePhysics == null)
                {
                    InitialisePhysicsSharedMemory();
                }

                using(var sharedMemoryStreamView = memoryMappedFilePhysics.CreateViewStream())
                {
                    BinaryReader _SharedMemoryStream = new BinaryReader(sharedMemoryStreamView);
                    sharedMemoryReadBufferPhysics = _SharedMemoryStream.ReadBytes(sharedMemorySizePhysics);
                    handle = GCHandle.Alloc(sharedMemoryReadBufferPhysics, GCHandleType.Pinned);
                    _Struct = (raw_data.AcPhysicsDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(raw_data.AcPhysicsDataStruct));
                    handle.Free();
                }

                return new Tuple<bool, raw_data.AcPhysicsDataStruct>(true, _Struct);
            }
            catch(Exception ex)
            {
                return new Tuple<bool, raw_data.AcPhysicsDataStruct>(false, _Struct);
            }
        }

        /// <summary>
        /// Read MMF -  data
        /// </summary>
        /// <returns>Struct with data</returns>
        public Tuple<bool, raw_data.AcStaticDataStruct> ReadStaticSharedMemoryData()
        {
            raw_data.AcStaticDataStruct _Struct = new raw_data.AcStaticDataStruct();

            try
            {
                if (memoryMappedFile == null)
                {
                    InitialiseStaticSharedMemory();
                }

                using (var sharedMemoryStreamView = memoryMappedFile.CreateViewStream())
                {
                    BinaryReader _SharedMemoryStream = new BinaryReader(sharedMemoryStreamView);
                    sharedMemoryReadBuffer = _SharedMemoryStream.ReadBytes(sharedMemorySize);
                    handle = GCHandle.Alloc(sharedMemoryReadBuffer, GCHandleType.Pinned);
                    _Struct = (raw_data.AcStaticDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(raw_data.AcStaticDataStruct));
                    handle.Free();
                }

                return new Tuple<bool, raw_data.AcStaticDataStruct>(true, _Struct);
            }
            catch(Exception ex)
            {
                return new Tuple<bool, raw_data.AcStaticDataStruct>(false, _Struct);
            }
        }
    }
}
