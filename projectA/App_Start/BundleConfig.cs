using System.Web;
using System.Web.Optimization;

namespace projectA
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib"

              ).Include(
                     "~/scripts/bootbox.js",
                    "~/scripts/respond.js",
                    "~/scripts/datatables/jquery.datatables.js",
                    "~/scripts/datatables/datatables.bootstrap.js",
                    "~/scripts/bootstrap-datepicker.js",
                     "~/scripts/typeahead.bundle.js"

                    ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/datatables/css/datatables.bootstrap.css",
                       "~/Content/typeahead.css",
                       "~/Content/bootstrap-datepicker.css",
                       "~/Content/bootstrap-datepicker3.css"
                      ));
        }
    }
}
