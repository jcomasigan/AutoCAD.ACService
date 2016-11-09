using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDataService
{
    class AC_Layers
    {
        public bool getStormWater { get; set; }
        public bool getWasteWater { get; set; }
        public bool getContours { get; set; }
        public bool getParcel { get; set; }
        public bool getAddress { get; set; }
        public bool getBuildingFootprint { get; set; }
        public bool getImpervious { get; set; }
        public bool getWater { get; set; }
        public SpatialReference SpatialRef { get; set; }
        public enum SpatialReference
        {
            MtEden,
            Nztm,
            WGS84
        }
    }
}
