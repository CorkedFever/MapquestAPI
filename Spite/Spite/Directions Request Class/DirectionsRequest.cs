using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapShell.Directions_Result_Class;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;

namespace MapShell.Directions_Request_Class
{
    abstract public class DirectionsRequest
    {
        public enum Avoids { LimitedAccess, TollRoad, SeasonalClosure, Unpaved, Ferry, CountryBorderCrossing };
        public enum RouteType { Fastest, Shortest, Pedestrian, Multimodal, Bicycle };
        public enum DrivingStyle { Normal, Cautious, Aggressive };

        public static Directions getDirections(Locations start, Locations end, RouteType routeType = RouteType.Fastest, DrivingStyle drivingStyle = DrivingStyle.Normal, List<Avoids> avoids = null, bool enhancedNarrative = false, bool metric = false, int fuelEfficiency = 21)
        {
            WebClient w = new WebClient();
            string url = ConfigurationManager.AppSettings["MapQuestDirectionsURL"] + ConfigurationManager.AppSettings["MapQuestAPIKey"];
            if (avoids != null)
            {
                foreach (Avoids a in avoids)
                    switch (a)
                    {
                        case Avoids.CountryBorderCrossing:
                            url += "&avoids=Country border";
                            break;
                        case Avoids.Ferry:
                            url += "&avoids=Ferry";
                            break;
                        case Avoids.LimitedAccess:
                            url += "&avoids=Limited Access";
                            break;
                        case Avoids.SeasonalClosure:
                            url += "&avoids=Approximate Seasonal Closure";
                            break;
                        case Avoids.TollRoad:
                            url += "&avoids=Toll road";
                            break;
                        case Avoids.Unpaved:
                            url += "&avoids=Unpaved";
                            break;
                        default:
                            break;
                    }
            }
            url += "&outFormat=json";
            switch (routeType)
            {
                case RouteType.Fastest:
                    url += "&routeType=fastest";
                    break;
                case RouteType.Shortest:
                    url += "&routeType=shortest";
                    break;
                case RouteType.Pedestrian:
                    url += "&routeType=pedestrian";
                    break;
                case RouteType.Bicycle:
                    url += "&routeType=bicycle";
                    break;
                case RouteType.Multimodal:
                    url += "&routeType=multimodal";
                    break;
                default:
                    url += "&routeType=fastest";
                    break;
            }
            url += "&timeType=1";
            url += (enhancedNarrative ? "&enhancedNarrative=true" : "&enhancedNarrative=false");
            url += "&shapeFormat=raw&generalize=0";
            url += ConfigurationManager.AppSettings["MapQuestDirectionsLocale"];
            url += (metric ? "&unit=k" : "&unit=m");
            url += "&from=" + (start.latLng == null ? 0 : start.latLng.lat) + ',' + (start.latLng == null ? 0 : start.latLng.lng);
            url += "&to=" + (end.latLng == null ? 0 : end.latLng.lat) + ',' + (end.latLng == null ? 0 : end.latLng.lng);
            url += "&drivingStyle=";
            switch (drivingStyle)
            {
                case DrivingStyle.Aggressive:
                    url += "3";
                    break;
                case DrivingStyle.Cautious:
                    url += "1";
                    break;
                case DrivingStyle.Normal:
                    url += "2";
                    break;
                default:
                    url += "2";
                    break;
            }
            url += "&highwayEfficiency=" + fuelEfficiency;
            JsonSerializerSettings s = new JsonSerializerSettings();
            s.NullValueHandling = NullValueHandling.Ignore;
            s.ObjectCreationHandling = ObjectCreationHandling.Replace;
            DirectionsRootObject result = JsonConvert.DeserializeObject<DirectionsRootObject>(w.DownloadString(url), s);
            return result.route;
        }

        public static List<Directions> getDirections(List<Locations> locations, RouteType routeType = RouteType.Fastest, DrivingStyle drivingStyle = DrivingStyle.Normal, List<Avoids> avoids = null, bool enhancedNarrative = false, bool metric = false, int fuelEfficiency = 21)
        {
            if (locations.Count < 2)
                return new List<Directions>();
            WebClient w = new WebClient();
            string url = ConfigurationManager.AppSettings["MapQuestDirectionsURL"] + ConfigurationManager.AppSettings["MapQuestAPIKey"];
            if (avoids != null)
            {
                foreach (Avoids a in avoids)
                    switch (a)
                    {
                        case Avoids.CountryBorderCrossing:
                            url += "&avoids=Country border";
                            break;
                        case Avoids.Ferry:
                            url += "&avoids=Ferry";
                            break;
                        case Avoids.LimitedAccess:
                            url += "&avoids=Limited Access";
                            break;
                        case Avoids.SeasonalClosure:
                            url += "&avoids=Approximate Seasonal Closure";
                            break;
                        case Avoids.TollRoad:
                            url += "&avoids=Toll road";
                            break;
                        case Avoids.Unpaved:
                            url += "&avoids=Unpaved";
                            break;
                        default:
                            break;
                    }
            }
            url += "&outFormat=json";
            switch (routeType)
            {
                case RouteType.Fastest:
                    url += "&routeType=fastest";
                    break;
                case RouteType.Shortest:
                    url += "&routeType=shortest";
                    break;
                case RouteType.Pedestrian:
                    url += "&routeType=pedestrian";
                    break;
                case RouteType.Bicycle:
                    url += "&routeType=bicycle";
                    break;
                case RouteType.Multimodal:
                    url += "&routeType=multimodal";
                    break;
                default:
                    url += "&routeType=fastest";
                    break;
            }
            url += "&timeType=1";
            url += (enhancedNarrative ? "&enhancedNarrative=true" : "&enhancedNarrative=false");
            url += "&shapeFormat=raw&generalize=0";
            url += ConfigurationManager.AppSettings["MapQuestDirectionsLocale"];
            url += (metric ? "&unit=k" : "&unit=m");
            List<Directions> result = new List<Directions>();
            for (int i = 1; i < locations.Count; ++i)
            {
                string tmp = url + "&from=" + (locations[i - 1].latLng == null ? 0 : locations[i - 1].latLng.lat)
                    + ',' + (locations[i - 1].latLng == null ? 0 : locations[i - 1].latLng.lng)
                    + "&to=" + (locations[i].latLng == null ? 0 : locations[i].latLng.lat)
                    + ',' + (locations[i].latLng == null ? 0 : locations[i].latLng.lng);
                url += "&drivingStyle=";
                switch (drivingStyle)
                {
                    case DrivingStyle.Aggressive:
                        url += "3";
                        break;
                    case DrivingStyle.Cautious:
                        url += "1";
                        break;
                    case DrivingStyle.Normal:
                        url += "2";
                        break;
                    default:
                        url += "2";
                        break;
                }
                url += "&highwayEfficiency=" + fuelEfficiency;
                JsonSerializerSettings s = new JsonSerializerSettings();
                s.NullValueHandling = NullValueHandling.Ignore;
                s.ObjectCreationHandling = ObjectCreationHandling.Replace;
                result.Add(JsonConvert.DeserializeObject<DirectionsRootObject>(w.DownloadString(tmp), s).route);
            }
            return result;
        }
    }
}
