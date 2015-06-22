using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    public class ShapeRoute
    {
        List<double> LatLngPairs;
        public string encode;
        
        
            
        //default constructor
        public ShapeRoute()
        {
            LatLngPairs = new List<double>();

        }
        


        //Shape class constructor that takes a list of lat long pairs to be placed in a compress function
        public ShapeRoute(List<double> inputLatLngPairs)//any list of input pairs can be passed here but the beginning and end coordinates are needed for Ecenter and Scenter
        {
            /*these are listed below to be able to test the base class return
            List<LatLng> inputLatLngPairs = new List<LatLng>();
            inputLatLngPairs.Add(new LatLng(40.03371, -76.50460));
            inputLatLngPairs.Add(new LatLng(40.03188, -76.50258));
            inputLatLngPairs.Add(new LatLng(40.03188, -76.50258));
            inputLatLngPairs.Add(new LatLng(40.02982, -76.50550));
            inputLatLngPairs.Add(new LatLng(40.02982, -76.50550));
            inputLatLngPairs.Add(new LatLng(40.02267, -76.49211));
            inputLatLngPairs.Add(new LatLng(39.99161, -76.46990));
            inputLatLngPairs.Add(new LatLng(39.99161, -76.46990));
            inputLatLngPairs.Add(new LatLng(39.99654, -76.45488));
            inputLatLngPairs.Add(new LatLng(39.99927, -76.42662));
            inputLatLngPairs.Add(new LatLng(40.00936, -76.39402));
            inputLatLngPairs.Add(new LatLng(40.00579, -76.36798));
            inputLatLngPairs.Add(new LatLng(40.00804, -76.35856));
            inputLatLngPairs.Add(new LatLng(40.00804, -76.35856));
            inputLatLngPairs.Add(new LatLng(39.99785, -76.35427));
            inputLatLngPairs.Add(new LatLng(39.99785, -76.35427));
            */
            
            LatLngPairs = inputLatLngPairs;
            encode = returnCompressedPairs(inputLatLngPairs, 6);

        }
        //function compresses pairs to return to the static map api in a form that is understood by the api
        public string returnCompressedPairs(List<double> toBeCompressed, int precision)
        {
            
           
            double oldLat = 0.0, oldLng = 0.0;
            int len = toBeCompressed.Count;
            string encoded = "";
            
            precision= (int)Math.Pow(10,precision);
            for (int i = 0; i < toBeCompressed.Count - 1;i+=2 )
            {
                double temp_lat = Math.Round(toBeCompressed[i] * precision);
                double temp_long = Math.Round(toBeCompressed[i+1] * precision);
                encoded += encodeNumber((int)(temp_lat - oldLat));
                encoded += encodeNumber((int)(temp_long - oldLng));
                oldLat = temp_lat;
                oldLng = temp_long;
            }
           
            return encoded;
        }
        public string encodeNumber(int num) 
        {
            //num = num << 1  bitwise shift left  ex: 0010<<1 = 0100
            //num = num * 2;
            num = num << 1;
            if (num < 0)
            { 
           // num= ~(num); bitwise function  ex: 5= 0101 ~5=1010
                //num = (-num) - 1;
                num = ~(num);
            }
            string encoded="";

           // while (num >= 0x20) means > 32
            while (num >= 0x20)
            { 
                //String.fromCharCode((0x20 | (num & 0x1f)) + 63) converts a set of unicode values into characters
            
                encoded += (char)((0x20 | (num & 0x1f)) + 63);
                num >>= 5;
            }
            encoded += (char)(num + 63);

            return encoded;
        }

        public List<LatLng> decompress(string encoded, double precision) 
        {
           
           precision = (double)Math.Pow(10.0,-precision);
           int len = encoded.Length, index=0; 
           double lat=0, lng = 0;
           List<LatLng> decoded =new List<LatLng>();
           while (index < len)
           {
               int b, shift = 0, result = 0;
               do
               {
                   b =((int)encoded[index++]) - 63;
                   result |= (b & 0x1f) << shift;
                   shift += 5;
               } while (b >= 0x20);
               double dlat = (Convert.ToBoolean((result & 1)) ? ~(result >> 1) : (result >> 1));
               lat += dlat;
               shift = 0;
               result = 0;
               do
               {
                   b = ((int)encoded[index++]) - 63;
                   result |= (b & 0x1f) << shift;
                   shift += 5;
               } while (b >= 0x20);
               double dlng = (Convert.ToBoolean((result & 1)) ? ~(result >> 1) : (result >> 1));
               lng += dlng;
               decoded.Add(new LatLng(lat * precision, lng * precision));
           }
            
            return decoded;
        }


    }
}
