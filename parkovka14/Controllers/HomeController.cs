using parkovka14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace parkovka14.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            DataContext kl = new DataContext();

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Point()
        {
            return View();
        }
        public ActionResult PartialPoint()
        {

            return PartialView();
        }

        public ActionResult Polygon()
        {
            return View();
        }



        public JsonResult GetPolygons()
        {

            List<clPolygon> pol = new List<clPolygon>();
            DataContext db = new DataContext();

            var G = from t in db.Polygons select t;
            foreach (Polygon pl in G)
            {
                pol.Add(new clPolygon()
                {
                    Id = pl.Id,
                    Number= pl.Number,
                   
                    lat = pl.lat,
                    lng = pl.lng
                });


            }

            return Json(pol, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetData()
        {


            List<Station> stations = new List<Station>();
            DataContext db = new DataContext();


            var t = from co in db.Points select co;
            foreach (Point Rt in t)
            {
                stations.Add(new Station()
                {
                    Id = Rt.Id,
                    Name = Rt.Name,
                    GeoLat = Rt.GeoLat,
                    GeoLong = Rt.GeoLong,

                    Cash = Rt.Cash,
                    Traffic = Rt.Traffic
                });

            }


            return Json(stations, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetPol()
        {

            List<clPolygon> pol = new List<clPolygon>();
            DataContext db = new DataContext();

            var G = from t in db.Polygons select t;
            foreach (Polygon pl in G)
            {
                pol.Add(new clPolygon()
                {
                    Id = pl.Id,

                    lat = pl.lat,
                    lng = pl.lng
                });


            }

            return Json(pol, JsonRequestBehavior.AllowGet);
        }

    }
}
