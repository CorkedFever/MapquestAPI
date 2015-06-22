using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    public class Size
    {
        public uint width;
        public uint height;

        //Default Constructor for the size class if no parameters are given
        public Size()
        {
            width = 400;
            height = 400;
        }

        //Constructor for size class with new parameters for size being passed
        public Size(uint width_, uint height_)
        {
            //ternary implemetation --- ternary means it takes 3 things compare and if true returns the 1st 
            //value, and 2nd value if false

            width = (width_ > 3840 ? 3840 : width_);
            height = (height_ > 3840 ? 3840 : height_);
            /*
            this.width = width_;
            if (width > 3840) 
            {
                width = 1500;
            }
            this.height = height_;
            if (height > 3840) 
            {
                height = 1500;
            }
             */
        }

        //Function that converts width and height to string and returns it as a string
        public string returnSizeString()
        {
            return Convert.ToString(width) + ',' + Convert.ToString(height);
        }

    }
}
