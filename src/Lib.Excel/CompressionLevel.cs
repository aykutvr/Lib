using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Excel
{
    //
    // Summary:
    //     Maps to DotNetZips CompressionLevel enum
    public enum CompressionLevel
    {
        //
        // Summary:
        //     Level 0, no compression
        Level0 = 0,
        //
        // Summary:
        //     No compression
        None = 0,
        //
        // Summary:
        //     Level 1, Best speen
        Level1 = 1,
        BestSpeed = 1,
        //
        // Summary:
        //     Level 2
        Level2 = 2,
        //
        // Summary:
        //     Level 3
        Level3 = 3,
        //
        // Summary:
        //     Level 4
        Level4 = 4,
        //
        // Summary:
        //     Level 5
        Level5 = 5,
        //
        // Summary:
        //     Level 6
        Level6 = 6,
        //
        // Summary:
        //     Default, Level 6
        Default = 6,
        //
        // Summary:
        //     Level 7
        Level7 = 7,
        //
        // Summary:
        //     Level 8
        Level8 = 8,
        //
        // Summary:
        //     Level 9
        BestCompression = 9,
        //
        // Summary:
        //     Best compression, Level 9
        Level9 = 9
    }
}
