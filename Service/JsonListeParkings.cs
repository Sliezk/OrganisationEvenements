using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Service
{
    public class JsonListeParkings
    {
        public park[] parks { get; set; }
        public FeatureCollection features { get; set; }
    }

    public class park
    {
        public parkinformation parkinformation { get; set; }
        public String id { get; set; }
    }

    public class parkinformation
    {
        public String name { get; set; }
        public String status { get; set; }
        public int max { get; set; }
        public int free { get; set; }
    }

    public class FeatureCollection
    {
        public String name { get; set; }
        public String status { get; set; }
        public int max { get; set; }
        public int free { get; set; }
    }

    public class Feature
    {
        public name[] crs { get; set; }
        public String id { get; set; }
    }

    public class name
    {
        public properties properties { get; set; }
        public Point geometry { get; set; }
        public String id { get; set; }
    }

    public class properties
    {
        public String name { get; set; }
    }

    public class Point
    {
        public GeoCoordinate coordinates { get; set; }
        public String id { get; set; }
    }
}
