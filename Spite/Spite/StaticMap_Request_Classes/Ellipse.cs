using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    //Class ellipse --- Takes a color, width, a pair of latitude and longitude, fill which is a color.
    public class Ellipse
    {
        string color;
        int width;
        List<LatLng> LatLngPairs;
        //&ellipse=fill:0x70ff0000|color:0xff0000|width:2|40.19,-76.35,40.13,-76.27
        
        string fill;

        //Default constructor for the Ellipse class
        public Ellipse()
        {
            //Variable declarations and initialization
            //color = 0x000000; // Defaulted to a hexidecimal representation of color
            color = "";
            width = 0;
            LatLngPairs = new List<LatLng>();
            

            fill = "";
           // fill = 0x000000; //Also defaulted to a hexidecimal representation of color
        }

        //Ellipse constructor
        public Ellipse(string inputColor, int inputWidth, List<LatLng> inputLatLngPairs, string inputFill)
        {
            color = inputColor;
            width = inputWidth;
            LatLngPairs = inputLatLngPairs;
            fill = inputFill;
        }

        //function returns values in the order requested in the api
        public string returnEllipseString()
        {
            string emptyEllipse = "";
            string result = "";
            string outfill = "fill:";
            string outcolor = "color:";
            string outwidth = "width:";

            if (color == "" && width == 0 && LatLngPairs.Count == 0 && fill == "")
            {
                return emptyEllipse;
            }

            else
            {
                
                
                result= "&ellipse="+outfill + Convert.ToString(fill) + '|' + outcolor + Convert.ToString(color)
                    + '|' + outwidth + Convert.ToString(width) + '|';
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
