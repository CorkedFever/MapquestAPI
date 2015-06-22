using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    public class Polyline
    {
        string color;
        int width = 0;
        List<LatLng> LatLngPairs;


        //Default constructor for the Polyline class
        public Polyline()
        {
            color = "";
            width = 0;
            LatLngPairs = new List<LatLng>();//&polyline=color:0x000000|width:5|40.07089,-76.3264,40.0622,-76.3429,40.0606,-76.3610,40.0526,-76.3757,40.0531,-76.3923
           //delete below stuff
        }

        //Polyline constructor
        public Polyline(string inputColor, int inputWidth, List<LatLng> inputLatLngPairs)
        {
            color = inputColor;
            width = inputWidth;
            LatLngPairs = inputLatLngPairs;
        }

        public string returnPolylineString()
        {
            string result = "";
            //Convert.ToString should always be used in a try catch bracket, just in case of a wrong input things will be handled properly

            if (LatLngPairs.Count == 0) { return result; }


            else
            {
                result += "&polyline=";
                //color:0x000000|width:5|40.07089,-76.3264,40.0622,-76.3429,40.0606,-76.3610,40.0526,-76.3757,40.0531,-76.3923
                result += "color:" +  Convert.ToString(color) + '|' + "width:" + Convert.ToString(width);


                //foreach (LatLng val in LatLngPairs)
                result += '|';

                for (int index = 0; index < LatLngPairs.Count; ++index)
                {
                    result += Convert.ToString(LatLngPairs[index].latitude) + ',' + Convert.ToString(LatLngPairs[index].longitude);
                    if (LatLngPairs.Count < LatLngPairs.Count - 1)
                    {
                        result += ',';
                    }
                }
            }
            return result;
        }
    }
}
