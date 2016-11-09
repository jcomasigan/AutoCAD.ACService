using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Colors;

namespace ACDataService
{
    class CAD
    {
        /// <summary>
        /// Calls the AutoCAD command zoom extents
        /// </summary>
        public static void ZoomExtents()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("._z e ", true, false, false);
        }
        /// <summary>
        /// Creates a new layer in the drawing
        /// </summary>
        /// <param name="layerName">Name of the layer to be created</param>
        /// <param name="colour">colour index of the new layer</param>
        private static void CreateLayer(string layerName, short colour)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                LayerTable layerTable = (LayerTable)tr.GetObject(currentDB.LayerTableId, OpenMode.ForWrite);
                if(!layerTable.Has(layerName))
                {
                    LayerTableRecord layer = new LayerTableRecord();
                    layer.Name = layerName;
                    layer.Color = Color.FromColorIndex(ColorMethod.ByLayer, colour);
                    ObjectId layerID = layerTable.Add(layer);
                    tr.AddNewlyCreatedDBObject(layer, true);
                    tr.Commit();
                }
            }
        }
        ///<summary> 
        ///Plots list of x & y coordinates to a closed polyline
        ///</summary>
        ///<param name="polyList">List of x & y coordinates. Format : "X /newline Y /newline</param>
        public static void DrawPlineFrom2PtList(string layerName, List<string> polyList, double elav = 0, bool closePoly = true)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            CreateLayer(layerName, 150);
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                BlockTable blckTable = tr.GetObject(currentDB.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blockTableRec = tr.GetObject(blckTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                Polyline polyLine = new Polyline();
                int j = 0; //counter for using pairs of coordinates in a single list.
                for(int i = 0; i < ((polyList.Count/ 2) - 1); i++)
                {
                    polyLine.AddVertexAt(i, new Point2d(Convert.ToDouble(polyList[j]), Convert.ToDouble(polyList[j + 1])), 0, 0, 0);
                    j += 2;
                }
                polyLine.Elevation = elav;
                polyLine.Closed = closePoly;   //Closes the polyline 
                polyLine.Layer = layerName;           
                blockTableRec.AppendEntity(polyLine); 
                tr.AddNewlyCreatedDBObject(polyLine, true);
                tr.Commit();             
            }
         }
        /// <summary>
        /// Draws 3 point list. ie list from XML data of contours. X,Y & elevation
        /// </summary>
        /// <param name="layerName">Layer Name of the polyline</param>
        /// <param name="colour">Colour code of polyline</param>
        /// <param name="polyList">List of points</param>
        /// <param name="elav">elevation point, seperated from the list</param>
        /// <param name="closePoly">Bool to close polyline.</param>
        public static void DrawPlineFrom3PtList(string layerName, short colour, List<string> polyList, double elav = 0, bool closePoly = true)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database currentDB = doc.Database;
            CreateLayer(layerName, colour);
            using (Transaction tr = currentDB.TransactionManager.StartTransaction())
            {
                BlockTable blckTable = tr.GetObject(currentDB.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blockTableRec = tr.GetObject(blckTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                Polyline polyLine = new Polyline();
                int j = 0; //counter for using pairs of coordinates in a single list.
                for (int i = 0; i < ((polyList.Count / 3) - 1); i++)
                {
                    polyLine.AddVertexAt(i, new Point2d(Convert.ToDouble(polyList[j+1]), Convert.ToDouble(polyList[j])), 0, 0, 0); //stupid chch contours is the other way around!
                    j += 3;
                }
                polyLine.Elevation = elav;
                polyLine.Closed = closePoly;   //Closes the polyline 
                polyLine.Layer = layerName;
                blockTableRec.AppendEntity(polyLine);
                tr.AddNewlyCreatedDBObject(polyLine, true);
                tr.Commit();
            }
        }

        static List<Tuple<double, double>> FormatLatLng(List<string> vertices, int noOfPoints = 2)
        {
            int j = 0; //counter for using pairs of coordinates in a single list.
            List<Tuple<double, double>> coordinates = new List<Tuple<double, double>>();
            for (int i = 0; i < ((vertices.Count / 2) - 1); i++)
            {
                Tuple<double, double> coordinate = Tuple.Create(Convert.ToDouble(vertices[j]), Convert.ToDouble(vertices[j+1]));
                coordinates.Add(coordinate);
                j += noOfPoints;
            }
            return coordinates;
        }
        /// <summary>
        /// Calculates the centroid of a polygon LINK:https://en.wikipedia.org/wiki/Centroid
        /// </summary>
        /// <param name="vertices">lat,lng coordinates</param>
        /// <returns>Returns the centroid of a polygon</returns>
        public static Tuple<double, double> GetCentroid(List<Tuple<double, double>> vertices)
        {           
            double signedArea = 0;
            double latC = 0, lngC = 0;
            double sum = 0;
            for(int i = 0; i < vertices.Count; i++)
            {
                int k = i + 1;
                if (i == vertices.Count - 1)
                {
                    k = 0; //To loop back to the first vertex
                }
                signedArea += ((vertices[i].Item1) * (vertices[k].Item2)) - ((vertices[k].Item1) * (vertices[i].Item2));
                latC += (vertices[i].Item1 + vertices[k].Item1) * ((vertices[i].Item1 * vertices[k].Item2) - (vertices[k].Item1 * vertices[i].Item2));
                lngC += (vertices[i].Item2 + vertices[k].Item2) * ((vertices[i].Item1 * vertices[k].Item2) - (vertices[k].Item1 * vertices[i].Item2));
            }
            signedArea *= 0.5;
            latC /= (6 * signedArea);
            lngC /= (6 * signedArea);
            return Tuple.Create(latC, lngC);
        }
        /// <summary>
        /// Creates mtext labels inside a close polyline
        /// </summary>
        /// <param name="vertices">Vertices of polyline; lat/long seperated each by /n </param>
        public static void DrawLabelsInPoly(List<string> vertices, string label1, string label2 = null, string label3 = null)
        {
            CreateLayer("Appellation", 30);
            List<Tuple<double, double>> coordinates = FormatLatLng(vertices);
            Tuple<double, double> latlng = GetCentroid(coordinates);
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable blockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blockTableRec = tr.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                using (MText mtext = new MText())
                {
                    mtext.Location = new Point3d(latlng.Item1, latlng.Item2, 0);
                    mtext.Width = 4;
                    mtext.Contents = label1;
                    mtext.Layer = "Appellation";
                    blockTableRec.AppendEntity(mtext);
                    tr.AddNewlyCreatedDBObject(mtext, true);
                }
                if (label2 != null)
                {
                    using (MText mtext2 = new MText())
                    {
                        mtext2.Location = new Point3d(latlng.Item1, latlng.Item2 + 10, 0);
                        mtext2.Width = 20;
                        mtext2.Contents = label2;
                        mtext2.Layer = "Appellation";
                        blockTableRec.AppendEntity(mtext2);
                        tr.AddNewlyCreatedDBObject(mtext2, true);
                    }
                }
                if (label3 != null)
                {
                    using (MText mtext3 = new MText())
                    {
                        mtext3.Location = new Point3d(latlng.Item1, latlng.Item2 + 20, 0);
                        mtext3.Width = 4;
                        mtext3.Layer = "Appellation";
                        mtext3.Contents = label3;
                        blockTableRec.AppendEntity(mtext3);
                        tr.AddNewlyCreatedDBObject(mtext3, true);
                    }
                }
                tr.Commit();
            }
        }
    }
}
