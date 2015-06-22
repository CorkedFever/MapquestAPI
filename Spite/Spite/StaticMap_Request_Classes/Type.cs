using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    public class Type
    {
        public string type;
        public enum TypeMap {map,hybrid,satellite};
        //default constructor
        public Type()
        {

            type = "map";
        
        }

        //class constructor

        public Type(Type.TypeMap input) 
        {
            
            //there are 3 'types' map/hybrid/satellite  default is 'map'
           
            
            switch (input)
            { 
                case TypeMap.hybrid:
                    type = "hybrid";
                    break;
                case TypeMap.satellite:
                    type = "satellite";
                    break;
                default:
                    type = "map";
                    break;
            
            }
        }
        public string returnType()
        {
            return Convert.ToString(type);
        }

    }
}
