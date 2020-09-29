<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Domain.MainModule.Entities.RiskReportInc>" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>RiskReport</title>    
    <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/RiskReportInc.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("dsGeneralInf", Model.GeneralInformation);
                ReportDataSource rdc1 = new ReportDataSource("dsUbicaciones", Model.Ubicaciones);
                ReportDataSource rdc2 = new ReportDataSource("dsCOPE", Model.COPE);
                ReportDataSource rdc3 = new ReportDataSource("dsASAreaFuego", Model.ASAreaInc);
                ReportDataSource rdc4 = new ReportDataSource("dsAS", Model.AS);
                
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.DataSources.Add(rdc1);
                ReportViewer1.LocalReport.DataSources.Add(rdc2);
                ReportViewer1.LocalReport.DataSources.Add(rdc3);
                ReportViewer1.LocalReport.DataSources.Add(rdc4);

                ReportViewer1.LocalReport.Refresh();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer>        
    </div>
    </form>
</body>
</html>
