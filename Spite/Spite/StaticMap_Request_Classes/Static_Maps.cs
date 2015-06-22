using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MapShell.Directions_Result_Class;

namespace MapShell.StaticMap_Request_Classes
{
    public class Static_Maps
    {
        //Default Constructor
        public Static_Maps(Shape shape2,uint width=620,uint height=480)
        {
            //Set every member variable to it's default value
            size = new Size(width,height);
            type = new Type(); //can also implement like type = "";
            mCenter = new Center();
            pCenter = new Center();
            sCenter = new Center(shape2.shapePoints[0], shape2.shapePoints[1]);
            eCenter = new Center(shape2.shapePoints[shape2.shapePoints.Count - 2], shape2.shapePoints[shape2.shapePoints.Count - 1]);
            declutter = false;
            xis = new List<XIS>();
            shapeformat = new ShapeFormat();
            shape = new ShapeRoute(shape2.shapePoints);
            ellipse = new Ellipse();
            polyline = new Polyline();
            polygon = new Polygon();
        }

        //Memo to me: Capitals indicates a class
        public Size size;

        //This will be a string we will be getting. No need to create a class. 
        //Classes are created for things that contain multi variable not one like the class type
        //default values below
        public Type type;
        public Center mCenter;
        public Center pCenter;
        public Center sCenter;
        public Center eCenter;
        public bool declutter=false;
        public Polyline polyline;
        public Polygon polygon;
        public Ellipse ellipse;
        public ShapeRoute shape;
        public List<XIS> xis;
        public ShapeFormat shapeformat;
        public Shape shape2;

       /* http://open.mapquestapi.com/staticmap/v4/getmap?key=YOUR_KEY_HERE&size=400,400&type=map&
        mcenter=40.0247,-76.4132,40,40&pcenter=40.0547,-76.3132,0,-40
        &xis=http://open.mapquestapi.com/media/images/money_sign.jpg,1,c,39.9803,-76.21054
        &declutter=false
        &shapeformat=cmp&shape=uajsFvh}qMlJsK??zKfQ??tk@urAbaEyiC??y]{|AaPsoDa~@wjEhUwaDaM{y@??t~@yY??DX
    &ellipse=fill:0x70ff0000|color:0xff0000|width:2|40.19,-76.35,40.13,-76.27
    &polyline=color:0x000000|width:5|40.07089,-76.3264,40.0622,-76.3429,40.0606,-76.3610,40.0526,-76.3757,40.0531
    ,-76.3923&polygon=color:0x00ff00|width:6|fill:0x8800ff00|40.0815,-76.2335,40.0882,-76.1808,40.0793,-76.2017
    ,40.0572,-76.2145&scenter=40.0337,-76.5047&ecenter=39.9978,-76.3545
         */
        //might wat to chnge this name to somethinglike getJson
        public string getInput()
        {
            string result = "http://open.mapquestapi.com/staticmap/v4/getmap?key=";
            result += ConfigurationManager.AppSettings["MapQuestAPIKey"];
            result += "&size="+size.returnSizeString();
            result += "&type=" + type.returnType();
            result += mCenter.returnCenterString();
            result += pCenter.returnCenterString();
            result += "&xis=";
            
            for (int index = 0; index < xis.Count; ++index)
            {
                result += Convert.ToString(xis[index].returnXISstring()); 
                if (xis.Count < xis.Count - 1)
                {
                    result += ',';
                }
                
            }


            result += "&declutter=" + (declutter ? "true" : "false");
            result +=  shapeformat.returnShpFormat();
            result += "&shape=" +Convert.ToString(shape.encode);
            result +=  ellipse.returnEllipseString();
            result +=  polyline.returnPolylineString();
            result +=  polygon.returnPolygonString();
            result +=  "&scenter="+sCenter.returnCenterString();
            result +=  "&ecenter="+eCenter.returnCenterString();


            return result;
        }
    
    
    
    }
}
