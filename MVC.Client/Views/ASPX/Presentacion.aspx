<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Domain.MainModule.Entities.Presentacion>" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>ReportViwer in MVC4 Application</title>    
    <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //List<MVCReportViwer.Customer> customers = null;
                //using (MVCReportViwer.MyDatabaseEntities dc = new MVCReportViwer.MyDatabaseEntities())
                //{
                //    customers = dc.Customers.OrderBy(a => a.CustomerID).ToList();
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/RPTReports/rptCustomer.rdlc");
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource rdc = new ReportDataSource("MyDataset", customers);
                //    ReportViewer1.LocalReport.DataSources.Add(rdc);
                //    ReportViewer1.LocalReport.Refresh();
                //}
                ReportViewer1.ShowToolBar = false;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/PresentacionCotizacion.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("dsCabecera", Model.DatosGenerales);
                ReportDataSource rdc1 = new ReportDataSource("dsPrima", Model.Primas);
                ReportDataSource rdc2 = new ReportDataSource("dsResumen", Model.Resumen);
                ReportDataSource rdc3 = new ReportDataSource("dsTexto", Model.Textos);
                ReportDataSource rdc4 = new ReportDataSource("dsEquipo", Model.Equipos);
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
        
        <%--<asp:Button ID="btnRefreshReport" runat="server" Style="display: none;" OnClick="btnRefreshReport_Click" />      --%>
    </div>
    </form>
</body>
</html>
