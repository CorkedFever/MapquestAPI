using Newtonsoft.Json;

namespace MapShell.Directions_Result_Class
{
    /// <summary>
    /// Nessessary for Newtonsoft to work properly.
    /// </summary>
    public class DirectionsRootObject
    {
        #region Variables
        public Directions route { get; set; }
        #endregion

        public DirectionsRootObject()
        {
            route = new Directions();
        }
    }
}