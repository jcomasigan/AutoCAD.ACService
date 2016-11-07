using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace ACDataService
{
    public partial class Map : Form
    {
        GMapOverlay ol;
        GMapPolygon pl;
        bool canResize;
        int mX, mY;
        double latTop = 0;
        double lngTop = 0;
        double latBottom = 0;
        double lngBottom = 0;
        Rectangle rect = new Rectangle();

        public Map()
        {
            InitializeComponent();
            initBoundingBox();
            InitGmap();
        }

        void initBoundingBox()
        {
            gMapControl.DragButton = MouseButtons.Right;
            List<PointLatLng> points = new List<PointLatLng>();
            pl = new GMapPolygon(points, "bbox");
            pl.Fill = new SolidBrush(Color.FromArgb(20, Color.White));
            pl.Stroke = new Pen(Color.Red, 4);
            ol = new GMapOverlay();
            ol.Polygons.Add(pl);
            gMapControl.Overlays.Add(ol);
        }

        void InitGmap()
        {
            gMapControl.Position = new PointLatLng(-36.792491, 174.763779);
            gMapControl.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
        }

        private void gMapControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Red, 2), rect);
        }

        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                rect = new Rectangle();
                latTop = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
                lngTop = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;
                canResize = true;
                mX = e.X; mY = e.Y;
                rect.Location = new Point(mX, mY);
            }

        }
        private void gMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                canResize = false;
                latBottom = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
                lngBottom = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;
                rect = WGS84toNZTM(rect);
            }
        }
        
        private Rectangle WGS84toNZTM(Rectangle bbx)
        {

            NZTG2000.geod_nztm(MathFunc.Deg2Rad(latTop), MathFunc.Deg2Rad(lngTop), ref latTop, ref lngTop);
            NZTG2000.geod_nztm(MathFunc.Deg2Rad(latBottom), MathFunc.Deg2Rad(lngBottom), ref latBottom, ref lngBottom);
            boundingBoxLabel.Text = string.Format("{0},{1} | {2}, {3}", Math.Round(latTop, 2), Math.Round(lngTop, 2), Math.Round(latBottom, 2), Math.Round(lngBottom, 2));
            return new Rectangle();
        }
        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (canResize)
            {
                if (mX < e.X)
                {
                    rect.X = mX;
                    rect.Width = e.X - mX;
                }
                else
                {
                    rect.X = e.X;
                    rect.Width = mX - e.X;
                }
                if (mY < e.Y)
                {
                    rect.Y = mY;
                    rect.Height = e.Y - mY;
                }
                else
                {
                    rect.Y = e.Y;
                    rect.Height = mY - e.Y;
                }
                gMapControl.Invalidate();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(addressSearchBox.Text != "")
            {
                RectLatLng bbx = new RectLatLng();
                gMapControl.Position =  SearchLogic.Search(addressSearchBox.Text, out bbx);
                gMapControl.SetZoomToFitRect(bbx);
                
            }
        }

        private void downloadDataButton_Click(object sender, EventArgs e)
        {

        }


    }
}
