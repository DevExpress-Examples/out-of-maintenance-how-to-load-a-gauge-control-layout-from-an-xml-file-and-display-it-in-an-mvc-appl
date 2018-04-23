Imports System
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Web.Mvc
Imports DevExpress.Web.ASPxGauges
Imports DevExpress.Web.ASPxGauges.Gauges.Circular

Namespace DXWebApplication1.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		<OutputCache(Duration := 1000, VaryByParam := "param")>
		Public Function RenderGauge(ByVal param As Single) As ActionResult
			Dim ctrl As New ASPxGaugeControl()

			ctrl.RestoreLayoutFromXml(Server.MapPath("~/App_Data/gauge.xml"))
			TryCast(ctrl.Gauges("myGauge"), CircularGauge).Scales("myScale").Value = param

			Dim stream As New MemoryStream()
			ctrl.ExportToImage(stream, ImageFormat.Png)

			stream.Seek(0, SeekOrigin.Begin)
			Return File(stream, "image/png")
		End Function
	End Class
End Namespace