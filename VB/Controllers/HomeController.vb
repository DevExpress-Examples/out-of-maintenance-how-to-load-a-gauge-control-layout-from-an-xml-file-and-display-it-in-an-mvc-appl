Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.ASPxClasses.Internal
Imports DevExpress.Web.ASPxGauges
Imports System.Drawing.Imaging
Imports DevExpress.Web.ASPxGauges.Gauges.Circular
Imports System.IO

Namespace Example.Controllers
	<HandleError> _
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			ViewData("Message") = "Welcome to DevExpress Extensions for ASP.NET MVC!"

			Return View()
		End Function

		<OutputCache(Duration := 1000, VaryByParam := "param")> _
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
