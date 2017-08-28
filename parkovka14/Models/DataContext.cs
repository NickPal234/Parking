using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace parkovka14.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Polygon> Polygons { get; set; }
        public DbSet<Point> Points { get; set; }
    
    }
    public class Point
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Traffic { get; set; }
        public string Cash { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
    }
   

    public class Polygon
    {
        public int Id { get; set; }
        public double lng { get; set; }
        public double lat { get; set; }
        public int Number { get; set; }
    }
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GeoLat { get; set; }
        public double GeoLong { get; set; }
        public string Cash { get; set; }
        public double Traffic { get; set; }
    }
    public class clPolygon
    {
        public int Id { get; set; }
        public double lng { get; set; }
        public double lat { get; set; }
        public int Number { get; set; }
    }

   
}