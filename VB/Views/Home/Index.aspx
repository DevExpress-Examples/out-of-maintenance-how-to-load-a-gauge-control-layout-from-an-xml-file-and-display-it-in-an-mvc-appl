<%@ Page Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:content id="Content1" contentplaceholderid="TitleContent" runat="server">
   How to load a gauge control layout from an XML file and display it in an MVC application
</asp:content>
<asp:content id="Content2" contentplaceholderid="MainContent" runat="server">
    <script type="text/javascript">
        var i = 0;
        var interval = 1000;
        var isReady = false;
        var intervalId = null;

        var urlTemplate = '<%=Url.Action("RenderGauge", "Home", New RouteValueDictionary(New With { .param = -1f}))%>';

        function btn1_OnClick(s, e) {
            document.getElementById('gaugeImg1').src = urlTemplate.replace("-1", spin.GetValue().toString());
        }

        function btn2_OnClick(s, e) {
            i = 0;

            if (interval != null) {
                clearInterval(intervalId);
                intervalId = null;
            }

            intervalId = setInterval(function () {
                if (isReady) {
                    isReady = false;

                    if (i > 100)
                        clearInterval(intervalId);

                    document.getElementById('gaugeImg2').src = urlTemplate.replace("-1", i);
                    i += 5;
                }
            }, interval);
        }

        function ImageReady() { isReady = true; }
    </script>
    <h2>
        <%
		  :
        %>
    </h2>
    <p>
        To learn more about DevExpress Extensions for ASP.NET MVC visit <a href="http://devexpress.com/Products/NET/Controls/ASP-NET-MVC/"
            title="ASP.NET MVC Website">http://devexpress.com/Products/NET/Controls/ASP-NET-MVC/</a>.
    </p>
    <div style="background: 1px solid Blue; width; 240px;">
        <table>
            <thead>
                <th colspan="2" style="width: 300px">
                    <img src='<%= Url.Action("RenderGauge", "Home", New With { .param = 23f}) %>' alt="Gauge showing data"
                        id="gaugeImg1" />
                </th>
                <th style="width: 300px">
                    <img src='<%=Url.Action("RenderGauge", "Home", New With { .param = 7f}) %>' alt="Gauge showing data"
                        id="gaugeImg2" onload="ImageReady()" />
                </th>
            </thead>
            <tbody>
                <td>
                    <%
					   Html.DevExpress().SpinEdit(
                       Function(settings)
                           settings.Name = "spin"

						   settings.Properties.NullText = "Enter a value"

						   settings.Properties.NumberFormat = SpinEditNumberFormat.Number
						   settings.Properties.NumberType = SpinEditNumberType.Integer
						   settings.Properties.MinValue = 0
						   settings.Properties.MaxValue = 100

						   settings.Properties.ValidationSettings.ValidationGroup = "gaugeImg"
						   settings.Properties.ValidationSettings.RequiredField.IsRequired = True
						   settings.Properties.ValidationSettings.Display = Display.Dynamic
						   settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithTooltip

						   settings.Width = Unit.Percentage(100)
						   settings.Properties.AllowNull = False
                      End Function
					  ).Render()
                    %>
                </td>
                <td>
                    <%
					   Html.DevExpress().Button(
                       Function(settings)
                           settings.Name = "btn1"
						   settings.Text = "Apply"

						   settings.ClientSideEvents.Click = "btn1_OnClick"

						   settings.ValidationGroup = "group"
                      End Function
					  ).Render()
                    %>
                </td>
                <td align="center">
                    <%
					   Html.DevExpress().Button(
                       Function(settings)
                           settings.Name = "btn2"
						   settings.Text = "Start Animation"
						   settings.ClientSideEvents.Click = "btn2_OnClick"
                      End Function
					  ).Render()
                    %>
                </td>
            </tbody>
        </table>
    </div>
</asp:content>
