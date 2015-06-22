namespace MapShell.Directions_Result_Class
{
    /// <summary>
    /// Longitude and Latitude ADT class.
    /// </summary>
    public class LatLng
    {
        #region Variables
        /// <summary>
        /// Returns longitude value. 
        /// Default: 0
        /// </summary>
        public double lng { get; set; }

        /// <summary>
        /// Returns latitude value. 
        /// Default: 0
        /// </summary>
        public double lat { get; set; }
        #endregion

        public LatLng()
        {
            lng = 0.0;
            lat = 0.0;
        }
    }
}