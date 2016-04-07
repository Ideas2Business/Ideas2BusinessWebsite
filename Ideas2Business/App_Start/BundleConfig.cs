using System.Web;
using System.Web.Optimization;

namespace Ideas2Business
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/general.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}