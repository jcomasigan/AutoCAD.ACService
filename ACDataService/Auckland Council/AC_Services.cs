using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using InvestViewer_wpf.Classes;
using GMap.NET;
using System.Windows.Media;

namespace ACDataService
{
    public enum ServiceType
    {
        STORMWATER,
        CHANNEL,
        WASTEWATER,
        WATERSUPPLY,
        GAS,
        FIBREOPTIC,
        CONTOURS

    };
    class GetACData
    {
        public static void GetData(Tuple<double, double, double, double> bbox, AC_Layers layers)
        {
            if(layers.getParcel)
            {
                using (AC_Parcel ac = new AC_Parcel())
                {
                    ac.GetData(bbox);
                }
            }
        }
    }
    class AC_Services : IDisposable
    {
        public readonly string baseUrl = "https://maps.aucklandcouncil.govt.nz/ArcGIS/rest/services/DataExport/MapServer/{0}/query?text=&geometry={1}&geometryType=esriGeometryEnvelope&inSR=&spatialRel=esriSpatialRelContains&where=&returnGeometry=true&outSR={2}&outFields={3}&f=pjson";

        public void Dispose() { }
        public virtual void GetData(Tuple<double, double, double, double> bbox)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    //Main
                    string url = string.Format(baseUrl, 21, FormatBbox(bbox));
                    string jsonResponse = wc.DownloadString(url);
                    wc.Headers.Add("Content-Type", "application/json");
                    ACstormwater_OBJ.ACServices ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                    //Private
                    url = string.Format(baseUrl, 22, FormatBbox(bbox));
                    jsonResponse = wc.DownloadString(url);
                    ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                    //Abandoned
                    url = string.Format(baseUrl, 23, FormatBbox(bbox));
                    jsonResponse = wc.DownloadString(url);
                    ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                    //Manhole
                    url = string.Format(baseUrl, 13, FormatBbox(bbox));
                    jsonResponse = wc.DownloadString(url);
                    ACstormwater_OBJ.ACServicesManhole mh = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServicesManhole>(jsonResponse);
                    DrawMarker(mh);
                }
            }
            catch
            {

            }
        }
        public void DrawMarker(ACstormwater_OBJ.ACServicesManhole manhole)
        {
            foreach (ACstormwater_OBJ.ACFeatureManHole feat in manhole.features)
            {
                if (feat.attributes.TLATYPENAME == "Standard Manhole")
                {
                    PointLatLng pt = new PointLatLng(feat.geometry.y, feat.geometry.x);
                }
            }
        }

        public virtual void DrawPoly(ACstormwater_OBJ.ACServices ac)
        {
            foreach (ACstormwater_OBJ.ACFeature feat in ac.features)
            {
                foreach (List<List<double>> paths in feat.geometry.paths)
                {
                    List<PointLatLng> points = new List<PointLatLng>();
                    foreach (List<double> line in paths)
                    {
                        PointLatLng point = new PointLatLng(line[1], line[0]);
                        points.Add(point);
                    }
                }
            }
        }


        public string FormatBbox(Tuple<double, double, double, double> _bbox)
        {
            var dEast_start = new double();
            var dNorth_start = new double();
            var dEast_end = new double();
            var dNorth_end = new double();
            NZTG2000.geod_nztm(MathFunc.Deg2Rad(_bbox.Item1), MathFunc.Deg2Rad(_bbox.Item2), ref dNorth_start, ref dEast_start);
            NZTG2000.geod_nztm(MathFunc.Deg2Rad(_bbox.Item3), MathFunc.Deg2Rad(_bbox.Item4), ref dNorth_end, ref dEast_end);
            string coord = string.Format("{0}%2C{1}%2C{2}%2C{3}", dEast_start.ToString(), dNorth_start.ToString(), dEast_end.ToString(), dNorth_end.ToString());
            return coord;
        }
    }

    class AC_WasteWater : AC_Services
    {

        public override void GetData(Tuple<double, double, double, double> bbox)
        {


            try
            {
                using (WebClient wc = new WebClient())
                {
                    //Main
                    string url = string.Format(baseUrl, 12, FormatBbox(bbox));
                    string jsonResponse = wc.DownloadString(url);
                    wc.Headers.Add("Content-Type", "application/json");
                    ACstormwater_OBJ.ACServices ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                    //Private
                    url = string.Format(url, 13, FormatBbox(bbox));
                    jsonResponse = wc.DownloadString(url);
                    ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                    //Manhole
                    url = string.Format(url, 4, FormatBbox(bbox));
                    jsonResponse = wc.DownloadString(url);
                    ACstormwater_OBJ.ACServicesManhole mh = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServicesManhole>(jsonResponse);
                    DrawMarker(mh);
                }
            }
            catch
            {

            }
        }

        public override void DrawPoly(ACstormwater_OBJ.ACServices ac)
        {
            foreach (ACstormwater_OBJ.ACFeature feat in ac.features)
            {
                foreach (List<List<double>> paths in feat.geometry.paths)
                {
                    List<PointLatLng> points = new List<PointLatLng>();
                    foreach (List<double> line in paths)
                    {
                        PointLatLng point = new PointLatLng(line[1], line[0]);
                        points.Add(point);
                    }
                }
            }
        }
    }

    class AC_WaterSupply : AC_Services
    {


        public override void GetData(Tuple<double, double, double, double> bbox)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    //Main
                    string url = string.Format(baseUrl, 31, FormatBbox(bbox));
                    string jsonResponse = wc.DownloadString(url);
                    wc.Headers.Add("Content-Type", "application/json");
                    ACstormwater_OBJ.ACServices ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                    //Main
                    url = string.Format(baseUrl, 32, FormatBbox(bbox));
                    jsonResponse = wc.DownloadString(url);
                    ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                    //Main
                    url = string.Format(baseUrl, 33, FormatBbox(bbox));
                    jsonResponse = wc.DownloadString(url);
                    wc.Headers.Add("Content-Type", "application/json");
                    ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                    //Main
                    url = string.Format(baseUrl, 34, FormatBbox(bbox));
                    jsonResponse = wc.DownloadString(url);
                    wc.Headers.Add("Content-Type", "application/json");
                    ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                }
            }
            catch
            {

            }
        }

        public override void DrawPoly(ACstormwater_OBJ.ACServices ac)
        {
            foreach (ACstormwater_OBJ.ACFeature feat in ac.features)
            {
                foreach (List<List<double>> paths in feat.geometry.paths)
                {
                    List<string> points = new List<string>();
                    foreach (List<double> line in paths)
                    {
                        points.Add(line[1].ToString());
                        points.Add(line[0].ToString());
                    }
                    CAD.DrawPlineFrom2PtList("Parcel", points, 0, true);
                }
            }
        }
    }

    class ACContours : AC_Services
    {
        string urlCont = "https://maps.aucklandcouncil.govt.nz/ArcGIS/rest/services/DataExport/MapServer/5/query?text=&geometry={1}&geometryType=esriGeometryEnvelope&inSR=&spatialRel=esriSpatialRelIntersects&where=&returnGeometry=true&outSR=4326&outFields=ELEVATION&f=pjson";
        public override void GetData(Tuple<double, double, double, double> bbox)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    //Main
                    string url = string.Format(urlCont, 36, FormatBbox(bbox));
                    string jsonResponse = wc.DownloadString(url);
                    wc.Headers.Add("Content-Type", "application/json");
                    ACstormwater_OBJ.ACServices ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                }
            }
            catch
            {

            }
        }

        public override void DrawPoly(ACstormwater_OBJ.ACServices ac)
        {
            foreach (ACstormwater_OBJ.ACFeature feat in ac.features)
            {
                foreach (List<List<double>> paths in feat.geometry.paths)
                {
                    List<PointLatLng> points = new List<PointLatLng>();
                    foreach (List<double> line in paths)
                    {
                        PointLatLng point = new PointLatLng(line[1], line[0]);
                        points.Add(point);
                    }
                }
            }
        }
    }

    class AC_Parcel : AC_Services
    {
        public override void GetData(Tuple<double, double, double, double> bbox)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    //Main 
                    string url = string.Format(baseUrl, 3, FormatBbox(bbox), "","");
                    string jsonResponse = wc.DownloadString(url);
                    wc.Headers.Add("Content-Type", "application/json");
                    ACstormwater_OBJ.ACServices ob = JsonConvert.DeserializeObject<ACstormwater_OBJ.ACServices>(jsonResponse);
                    DrawPoly(ob);
                }
            }
            catch 
            {

            }
        }

        public override void DrawPoly(ACstormwater_OBJ.ACServices ac)
        {
            List<string> points = new List<string>();
            foreach (ACstormwater_OBJ.ACFeature feat in ac.features)
            {
                foreach (List<List<double>> paths in feat.geometry.paths)
                {
                    foreach (List<double> line in paths)
                    {
                        points.Add(line[1].ToString());
                        points.Add(line[0].ToString());
                    }
                    CAD.DrawPlineFrom2PtList("Parcel", points, 0, true);
                }
            }
            CAD.DrawPlineFrom2PtList("HAHA", points, 0, true);
        }
    }
}

