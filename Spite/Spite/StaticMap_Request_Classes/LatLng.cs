using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    public class LatLng
    {
        public double latitude;
        public double longitude;

        public LatLng()
        {
            latitude = 200;
            longitude = 200;
        }

        public LatLng(double Latitude_, double Longitude_)
        {
            latitude = Latitude_;
            longitude = Longitude_;
        }

        /*
        public LatLng(string json)
        {
            string tmp = Directions.JsonParser(json, "lng", 2, ',');
            try
            {
                //Ternary operator to check size of string, if size/length is zero set equal to invalid default value 200
                //Else perform Convert.ToDouble on it to get the double
                longitude = (tmp.Length > 0 ? Convert.ToDouble(tmp) : 200);
            }
            //Can throw two exceptions Format and overflow, overflow should not happen because of the limits on Lat/Long
            catch (Exception)
            {
                longitude = 200;    //If an exception was thrown set to invalid default 200
            }
            tmp = Directions.JsonParser(json, "lat", 2, '}');
            try
            {
                //Ternary operator to check size of string, if size/length is zero set equal to invalid default value 200
                //Else perform Convert.ToDouble on it to get the double
                latitude = (tmp.Length > 0 ? Convert.ToDouble(tmp) : 200);
            }
            //Can throw two exceptions Format and overflow, overflow should not happen because of the limits on Lat/Long
            catch (Exception)
            {
                latitude = 200;    //If an exception was thrown set to invalid default 200
            }
        }
         */ 

        public void print()
        {
            Console.WriteLine("LatLng:");
            Console.Write("\tLatitude: ");
            Console.WriteLine(latitude);
            Console.Write("\tLongitude: ");
            Console.WriteLine(longitude);
            Console.WriteLine("End LatLng");
        }
    }
}
