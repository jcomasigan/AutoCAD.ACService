using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestViewer_wpf.Classes
{
    class ACstormwater_OBJ
    {

        public class ACFieldAliases
        {
            public string TLATYPENAME { get; set; }
            public string SHAPE_Length { get; set; }
        }

        public class ACSpatialReference
        {
            public int wkid { get; set; }
        }

        public class ACAttributes
        {
            public string TLATYPENAME { get; set; }
            public double SHAPE_Length { get; set; }
            public string ACCURACY { get; set; }
            public string MATERIAL { get; set; }
            public double ELEVATION { get; set; }
            public string COMPKEY { get; set; }           
        }

        public class ACGeometry
        {
            public List<List<List<double>>> paths { get; set; }
        }

        public class ACGeometryManhole
        {
            public double x { get; set; }
            public double y { get; set; }
        }

        public class ACFeatureManHole
        {
            public ACAttributes attributes { get; set; }
            public ACGeometryManhole geometry { get; set; }
        }

        public class ACFeature
        {
            public ACAttributes attributes { get; set; }
            public ACGeometry geometry { get; set; }
        }



        public class ParcelFeature
        {

        }

        public class ACServices
        {
            public string displayFieldName { get; set; }
            public ACFieldAliases fieldAliases { get; set; }
            public string geometryType { get; set; }
            public ACSpatialReference spatialReference { get; set; }
            public List<ACFeature> features { get; set; }
        }

        public class ACServicesManhole
        {
            public string displayFieldName { get; set; }
            public ACFieldAliases fieldAliases { get; set; }
            public string geometryType { get; set; }
            public ACSpatialReference spatialReference { get; set; }
            public List<ACFeatureManHole> features { get; set; }
        }

        public class ACParcel
        {
            public string displayFieldName { get; set; }
            public ACFieldAliases fieldAliases { get; set; }
            public string geometryType { get; set; }
            public ACSpatialReference spatialReference { get; set; }
            public List<ACFeature> features { get; set; }
        }
    }
}
