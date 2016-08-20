using System.Web;
using System.Web.Optimization;

namespace BowlingApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Angular")
                .Include("~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/App")
                .Include("~/Scripts/App/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/Bowling")
                .IncludeDirectory("~/Scripts/App/Bowling", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/Frame")
                .IncludeDirectory("~/Scripts/App/Frame", "*.js"));

            bundles.Add(new LessBundle("~/Content/less").Include("~/Content/*.less"));

        }
    }
}
