using MapShell.Directions_Result_Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MapShell.Directions_Request_Class
{
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }

        public Address()
        {
            street = String.Empty;
            city = String.Empty;
            state = String.Empty;
            postalCode = String.Empty;
        }

        public Address(string _street = "", string _city = "", string _state = "", string _postalCode = ""){
            street = _street;
            city = _city;
            state = _state;
            postalCode = _postalCode;
        }

        public List<Locations> getLocations()
        {
            System.Net.WebClient w = new System.Net.WebClient();
            string json = w.DownloadString("http://open.mapquestapi.com/geocoding/v1/address?key="
                + System.Configuration.ConfigurationManager.AppSettings["MapQuestAPIKey"]
                + "&street=" + street + "&city=" + city + "&state=" + state + "&postalCode=" + postalCode);
            LocationsRootObject result = JsonConvert.DeserializeObject<LocationsRootObject>(json);
            return (result.results.Count > 0 ? result.results[0].locations : new List<Locations>());
        }

        public static List<Locations> getLocations(string street_, string city_, string state_, string postalCode_)
        {
            System.Net.WebClient w = new System.Net.WebClient();
            string json = w.DownloadString("http://open.mapquestapi.com/geocoding/v1/address?key="
                + System.Configuration.ConfigurationManager.AppSettings["MapQuestAPIKey"]
                + "&street=" + street_ + "&city=" + city_ + "&state=" + state_ + "&postalCode=" + postalCode_);
            LocationsRootObject result = JsonConvert.DeserializeObject<LocationsRootObject>(json);
            return (result.results.Count > 0 ? result.results[0].locations : new List<Locations>());
        }

        public static List<Locations> getLocations(double lat_, double lng_)
        {
            System.Net.WebClient w = new System.Net.WebClient();
            string json = w.DownloadString("http://open.mapquestapi.com/geocoding/v1/reverse?key="
                + System.Configuration.ConfigurationManager.AppSettings["MapQuestAPIKey"]
                + "&location=" + lat_ + ',' + lng_);
            LocationsRootObject result = JsonConvert.DeserializeObject<LocationsRootObject>(json);
            return (result.results.Count > 0 ? result.results[0].locations : new List<Locations>());
        }
    }
}