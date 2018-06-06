﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    public class GoogleGeocoder : IGeocoder
    {
        private const string ServiceUri = "http://maps.googleapis.com/maps/api/geocode/xml?address={0}&region=be&sensor=false";

        public Coordinates Geocode(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException("address");

            string requestUriString = string.Format(ServiceUri, Uri.EscapeDataString(address));

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUriString);

            try
            {
                WebResponse response = request.GetResponse();

                XDocument xdoc = XDocument.Load(response.GetResponseStream());

                // Verify the GeocodeResponse status
                string status = xdoc.Element("GeocodeResponse").Element("status").Value;
                //ValidateGeocodeResponseStatus(status, address);

                XElement locationElement = xdoc.Element("GeocodeResponse").Element("result").Element("geometry").Element("location");
                double latitude = (double)locationElement.Element("lat");
                double longitude = (double)locationElement.Element("lng");

                return new Coordinates(latitude, longitude);
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.NameResolutionFailure:
                        throw new Exception("The Google Maps geocoding service appears to be offline.", ex);
                    default:
                        throw;
                }
            }

        }

        private void ValidateGeocodeResponseStatus(string status, string address)
        {
            switch (status)
            {
                case "ZERO_RESULTS":
                    string message = string.Format("No coordinates found for address \"{0}\".", address);
                    throw new Exception(message);
                case "OVER_QUERY_LIMIT":
                    throw new Exception();
                case "OK":
                    break;
                default:
                    throw new Exception("Unkown status code: " + status + ".");
            }
        }

    }
}
