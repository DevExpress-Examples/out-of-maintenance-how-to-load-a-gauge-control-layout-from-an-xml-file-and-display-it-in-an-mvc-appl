using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGauges;
using System.Drawing.Imaging;
using DevExpress.Web.ASPxGauges.Gauges.Circular;
using System.IO;

namespace Example.Controllers {
    [HandleError]
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewData["Message"] = "Welcome to DevExpress Extensions for ASP.NET MVC!";

            return View();
        }

        [OutputCache(Duration = 1000, VaryByParam = "param")]
        public ActionResult RenderGauge(float param) {
            ASPxGaugeControl ctrl = new ASPxGaugeControl();

            ctrl.RestoreLayoutFromXml(Server.MapPath("~/App_Data/gauge.xml"));
            (ctrl.Gauges["myGauge"] as CircularGauge).Scales["myScale"].Value = param ;

            MemoryStream stream = new MemoryStream();
            ctrl.ExportToImage(stream, ImageFormat.Png);
            
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "image/png");
        }
    }
}
