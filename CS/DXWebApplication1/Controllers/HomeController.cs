using System;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;
using DevExpress.Web.ASPxGauges;
using DevExpress.Web.ASPxGauges.Gauges.Circular;

namespace DXWebApplication1.Controllers {
    public class HomeController: Controller {
        public ActionResult Index() {
            return View();
        }

        [OutputCache(Duration = 1000, VaryByParam = "param")]
        public ActionResult RenderGauge(float param) {
            ASPxGaugeControl ctrl = new ASPxGaugeControl();

            ctrl.RestoreLayoutFromXml(Server.MapPath("~/App_Data/gauge.xml"));
            (ctrl.Gauges["myGauge"] as CircularGauge).Scales["myScale"].Value = param;

            MemoryStream stream = new MemoryStream();
            ctrl.ExportToImage(stream, ImageFormat.Png);

            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "image/png");
        }
    }
}