using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    // Will take in all the components of the map and print out the map as the user will see
    public class Polygon
    {
        string color;
        int width;
        List<LatLng> LatLngPairs;
        string fill;

        //Default constructor for the Polygon class
        public Polygon()
        {
            color = ""; // default color
            width = 0;
            LatLngPairs = new List<LatLng>(); // Initializing a non-primitive. Primitives are initialized like(int = 0;)
            fill = "";
        }

        //Polygon class constructor
        //color:0x00ff00|width:6|fill:0x8800ff00|40.0815,-76.2335,40.0882,-76.1808,40.0793,-76.2017,40.0572,-76.2145
        public Polygon(string inputColor, int inputWidth,string inputFill, List<LatLng> inputLatLngPairs)
        {
            color = inputColor;
            width = inputWidth;
            LatLngPairs = inputLatLngPairs;
            fill = inputFill;
        }

        public string returnPolygonString()
        {
            string result = "";
            string outPolygon = "";
            //Convert.ToString should always be used in a try catch bracket, just in case of a wrong input things will be handled properly
            if (color == "" && width == 0 && LatLngPairs.Count==0)
            {
                outPolygon = "";
                return outPolygon;
            }
            else
            {
                //color:0x000000|width:5|40.07089,-76.3264,40.0622,-76.3429,40.0606,-76.3610,40.0526,-76.3757,40.0531,-76.3923
                result = "color:" + Convert.ToString(color) + '|' + "width:" + Convert.ToString(width) + '|' + "fill:" + Convert.ToString(fill)
                    + "|";


                //foreach (LatLng val in LatLngPairs)
                for (int index = 0; index < LatLngPairs.Count; ++index)
                {
                    result += Convert.ToString(LatLngPairs[index].latitude) + ',' + Convert.ToString(LatLngPairs[index].longitude);
                    if (LatLngPairs.Count < LatLngPairs.Count - 1)
                    {
                        result += ',';
                    }
                }
                return result;
            }
        }

    }
}
