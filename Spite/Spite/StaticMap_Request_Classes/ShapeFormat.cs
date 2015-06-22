using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{

    public class ShapeFormat
    {

        public enum SFormat { delta, cmp, raw, cmp6 };
        public string shpformat;

        //default constructor Shapeformat
        public ShapeFormat()
        {
            shpformat = "cmp6";
        }

        //ctor for shapeformat
        public ShapeFormat(ShapeFormat.SFormat input)   
        {
            /* delta - First shape point is represented in mutliples of 106 and subsequent points is given
                       as difference from previous point.
               raw -   Shape is represented as latitude/longitude pairs.
               cmp -   Shape is represented as a compressed path string with 5 digits of precision.
               cmp6 -  Same as cmp, but uses 6 digits of precision.
             */
            
                switch (input)
                {
                    case SFormat.delta:
                        shpformat = "delta";
                        break;
                    case SFormat.cmp:
                        shpformat = "cmp";
                        break;
                    case SFormat.raw:
                        shpformat = "raw";
                        break;
                    default:
                        shpformat = "cmp6";
                        break;

                }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string returnShpFormat()
        {

           // shpformat = "cmp6";
           string  retVal ="&shapeformat="+ Convert.ToString(shpformat);
           
            return retVal;
        }
    }
}

