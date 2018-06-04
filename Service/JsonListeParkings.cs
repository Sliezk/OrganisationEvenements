﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Service
{
    /*
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
        public Feature[] features { get; set; }
    }

    public class Feature
    {
        public name crs { get; set; }
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

    }
    */

    public class ParkInformation
    {
        public string name { get; set; }
        public string status { get; set; }
        public int max { get; set; }
        public int free { get; set; }
    }

    public class Park
    {
        public ParkInformation parkInformation { get; set; }
        public string id { get; set; }
    }

    public class Properties
    {
        public string name { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Crs crs { get; set; }
        public Geometry geometry { get; set; }
        public string id { get; set; }
    }

    public class Features
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }

    public class JsonListeParkings
    {
        public List<Park> parks { get; set; }
        public Features features { get; set; }
    }

}
