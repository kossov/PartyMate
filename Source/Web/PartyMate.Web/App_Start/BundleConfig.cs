using System.Web;
using System.Web.Optimization;

namespace PartyMate.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo-css").Include(
                      "~/Content/Kendo/kendo.common.min.css",
                      "~/Content/Kendo/kendo.metro.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendojs").Include(
                      "~/Scripts/Kendo/kendo.all.min.js",
                      "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rating").Include(
                        "~/Scripts/ratingsjs/js/star-rating.min.js",
                        "~/Scripts/ratingsjs/js/star-rating_locale_LANG.js"));

            bundles.Add(new StyleBundle("~/Content/rating").Include(
                    "~/Content/ratingscss/css/star-rating.css",
                    "~/Content/ratingscss/css/theme-krajee-svg.css"));

            bundles.Add(new ScriptBundle("~/bundles/maps").Include(
            "~/Scripts/Maps/homePageMaps.js"));

            bundles.Add(new ScriptBundle("~/bundles/maps").Include(
            "~/Scripts/Maps/map.js"));
        }
    }
}
