using System;
using System.Runtime.InteropServices;

namespace AMS2ChEd.Services
{

    [StructLayout(LayoutKind.Sequential)]
    public struct pCars2SharedMemory
    {
        public int mVersion;                // always > 0 when valid
        public int mBuildVersionNumber;
        public int mGameState;
        public int mSessionState;
    }
}



