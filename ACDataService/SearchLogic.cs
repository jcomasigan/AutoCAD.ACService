using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GMap.NET;
using System.Windows.Forms;

namespace ACDataService
{
    class SearchLogic
    {

        /// <summary>
        /// Checks input for address, job number or jobname
        /// </summary>
        /// <param name="input">string from search box</param>
        /// <returns>Lat Lng coordinates of input</returns>
        public static PointLatLng Search(string input, out RectLatLng bbox)
        {
            //Add nz to string and change zoom level if it's town to search or street
            PointLatLng pt = new PointLatLng(0, 0);
            bbox = new RectLatLng();
            string addressToGeocode = input;
            GeocodeAddress(addressToGeocode, out pt, out bbox);
            return pt;
        }



        /// <summary>
        /// Checks wether input is a road.
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Zoom level</returns>
        public static int ZoomLevel(string address)
        {
            int zoom = 10;
            bool isStreet = address.Any(char.IsDigit);
            bool ContainStreetRoadPlace = false;
            //If search string contains this then zoom in more.
            List<string> RoadStreetPlace = new List<string> {" st ", " ST ", " rd ", " RD ", " ave ", " AVE ", " Ave ",
                                                             " cres ", " CRESCENT ", " Cres", " pl ", " place ", " Place ",
                                                             " PLACE ", " street ", " STREET ", " Street ", " road ", " Road ",
                                                             " ROAD ", " st,", " ST,", " rd,", " RD,", " ave,", " AVE,", " Ave,",
                                                             " cres,", " CRESCENT,", " Cres,", " pl,", " place,", " Place,",
                                                             " PLACE,", " street,", " STREET,", " Street,", " road,", " Road,",
                                                             " ROAD,"};
            foreach (string s in RoadStreetPlace)
            {
                if (address.Contains(s))
                {
                    ContainStreetRoadPlace = true;
                }
            }

            if (isStreet || ContainStreetRoadPlace)
            {
                zoom = 18;
            }
            else
            {
                zoom = 15;
            }

            return zoom;
        }


        /// <summary>
        /// Geocodes the address input
        /// </summary>
        /// <param name="address">address</param>
        /// <returns>WGS84 Lattitude/Longitude coordinates of the address</returns>
        public static void GeocodeAddress(string address, out PointLatLng addressLatLng, out RectLatLng bbox)
        {
            bbox = new RectLatLng();
            DataSet googleXmlResult = new DataSet();
            DataTable locationTable = new DataTable();
            DataTable swTable = new DataTable();
            DataTable neTable = new DataTable();
            double lat;
            double lng;
            double lat1 = 0, lng1 = 0 , lat2 = 0, lng2 = 0;
            addressLatLng = new PointLatLng();
            string webUsableAddy = Uri.EscapeUriString(address);
            try
            {
                String url = "https://maps.googleapis.com/maps/api/geocode/xml?address=" + webUsableAddy;
                googleXmlResult.ReadXml(url);
                locationTable = googleXmlResult.Tables["location"];
                if (locationTable != null)
                {
                    for (int i = 0; i < locationTable.Rows.Count; i++)
                    {
                        lat = Convert.ToDouble(locationTable.Rows[i]["lat"].ToString());
                        lng = Convert.ToDouble(locationTable.Rows[i]["lng"].ToString());
                        addressLatLng = new PointLatLng(lat, lng);
                    }                    
                }
                swTable = googleXmlResult.Tables["southwest"];
                if (swTable != null)
                {
                    for (int i = 0; i < swTable.Rows.Count; i++)
                    {
                        lat = Convert.ToDouble(swTable.Rows[i]["lat"].ToString());
                        lng = Convert.ToDouble(swTable.Rows[i]["lng"].ToString());
                        lat1 = lat;
                        lng1 = lng;
                    }     
                }
                neTable = googleXmlResult.Tables["northeast"];
                if (neTable != null)
                {
                    for (int i = 0; i < neTable.Rows.Count; i++)
                    {
                        lat = Convert.ToDouble(neTable.Rows[i]["lat"].ToString());
                        lng = Convert.ToDouble(neTable.Rows[i]["lng"].ToString());
                        lat2 = lat;
                        lng2 = lng;
                    }
                    bbox = new RectLatLng(lat2, lng2, lat2 - lat1, lng2 - lng1);
                }
            }
                
            catch (Exception e)
            {
                MessageBox.Show("Error searching address. " + e.ToString());
                addressLatLng = new PointLatLng();
            }
        }
    }
}
