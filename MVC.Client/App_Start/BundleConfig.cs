using System.Web;
using System.Web.Optimization;

namespace MVC.Client
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/flatUiJsBundle").Include(
                //"~/Scripts/flatui/bootstrap.js",
                "~/Scripts/flatui/flat-ui.js",
                "~/Scripts/flatui/application.js",
                "~/Scripts/multiselect/jquery.multiselect.js",
                "~/Scripts/multiselect/jquery.multiselect.filter.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/editable").Include(
               "~/Scripts/editable/bootstrap-editable.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/selectList").Include(
               "~/Scripts/selectList/jquery.selectlistactions.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/timeout").Include(
               "~/Scripts/timeout/timeout-dialog.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/typehead").Include(
                "~/Scripts/typehead/bootstrap-tagsinput.js",               
                "~/Scripts/typehead/bootstrap-tagsinput-angular.js",
                "~/Scripts/typehead/typehead.bundle.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/dynatable").Include(
               "~/Scripts/dynatable/jquery.dynatable.js"
               ));
           
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/site.js",
                        "~/Scripts/popper.js",
                        "~/Scripts/main.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/menu_Personal").Include("~/Content/menu/menu.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/style.css"));
            bundles.Add(new StyleBundle("~/Content/editable").Include("~/Content/editable/bootstrap-editable.css"));
            bundles.Add(new StyleBundle("~/Content/dynatable_personal").Include("~/Content/dynatable/jquery.dynatable.css"));
            bundles.Add(new StyleBundle("~/Content/flatUiCssBundle").Include(
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/flatui/bootstrap.css",
                "~/Content/flatui/sticky-footer.css",
                "~/Content/flatui/flat-ui.css",
                "~/Content/flatui/custom.css",
                "~/Content/multiselect/jquery.multiselect.css",
                "~/Content/multiselect/jquery.multiselect.filter.css"
                ));

            bundles.Add(new StyleBundle("~/Content/timeout").Include("~/Content/timeout/timeout-dialog.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            //BundleTable.EnableOptimizations = true;
        }
    }
}
