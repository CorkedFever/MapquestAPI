using System;

namespace MapShell.StaticMap_Request_Classes
{
    public class Center
    {
        double LAT;
        double LNG;
        int OFFX;
        int OFFY;


        //Default contructor for class center with no given parameters
        public Center()
        {
            //All set to their default as specified by the problem domain
            LAT = 0;
            LNG = 0;
            OFFX = 0;
            OFFY = 0;
        }

        //Class ctor
        public Center(double inputLat, double inputLng, int inputOffx=0, int inputOffy=0)
        {
            
            

            //No limit on OFFY/OFFY so will not test for upper and lower bounds
            OFFX = inputOffx;
            OFFY = inputOffy;


            // Using nested ternary to test for upper and lower bounds : if > 90 assign 90 if < -90 assign -90 else assign input
            LAT = (inputLat > 90 ? 90 : (inputLat < -90 ? -90 : inputLat));

            // Using nested ternary for longitude to test for upper and lower bounds. Takes values between -180 and 180
            LNG = (inputLng > 180 ? 180 : (inputLng < -180 ? -180 : inputLng));

        }

        


        //A function that creates a specific part of the Json that this Center class refers to
        public string returnCenterString()
        {
            string empty = "";
            if (LAT == 0 && LNG == 0 && OFFX == 0 && OFFY == 0)
            {
                return empty;
            }
            else
            {
                return Convert.ToString(LAT) + ',' + Convert.ToString(LNG) + ',' + Convert.ToString(OFFX) + ',' + Convert.ToString(OFFY);
            }
        }
    }
}