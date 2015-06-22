using System.Collections.Generic;

namespace MapShell.Directions_Result_Class
{
    public class Shape
    {
        #region Variables
        //public List<int> maneuverIndexes { get; set; }  //Probably not needed
        public List<double> shapePoints { get; set; }
        //public List<int> legIndexes { get; set; } //Probably not needed
        #endregion
        public Shape()
        {
            shapePoints = new List<double>();
        }
    }
}