using AMS2ChEd.Models;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS2ChEd.Services
{
    public class SharedMemoryReader : IDisposable
    {
        private MemoryMappedFile _mmf;
        private MemoryMappedViewAccessor _accessor;

        public bool Init()
        {
            try
            {
                _mmf = MemoryMappedFile.OpenExisting("$pcars2$");   // <-- AMS2 uses same name
                _accessor = _mmf.CreateViewAccessor();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool IsRaceFinished
        {
            get
            {
                // Implement detection logic using Graphics/SessionState or flags
                return false; // placeholder
            }
        }

        public pCars2SharedMemory Read()
        {
            if (_accessor == null)
                return default;

            pCars2SharedMemory data = new pCars2SharedMemory();
            _accessor.Read(0, out data);
            return data;
        }


        public RaceResult CaptureFinalClassification()
        {
            // Build RaceResult from Participants data
            return new RaceResult()
            { 
                Classification = null,
                UpdatedStandings = null
            };

        }


        public void Dispose()
        {
            // Cleanup handles
            _accessor?.Dispose();
            _mmf?.Dispose();
        }
    }
}
