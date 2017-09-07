using System.Web;
using System.Web.Optimization;

namespace GitHubExplorer
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/datatables.bootstrap.js",
                        "~/Scripts/DataTables/datatables.responsive.js"));

            bundles.Add(new StyleBundle("~/Content/datatables/css").Include(
                        "~/Content/DataTables/css/jquery.dataTables.css"));
            





            //bundles.Add(new StyleBundle("~/Content/plugins/dataTables/dataTablesStyles").Include(
            //"~/Content/plugins/dataTables/datatables.min.css"));

            //// dataTables
            //bundles.Add(new ScriptBundle("~/plugins/dataTables").Include(
            //          "~/Scripts/plugins/dataTables/jquery.dataTables.js",
            //          "~/Scripts/plugins/dataTables/dataTables.bootstrap.js",
            //          "~/Scripts/plugins/dataTables/dataTables.responsive.js",
            //          "~/Scripts/plugins/dataTables/dataTables.tableTools.min.js"));
        }
    }
}
