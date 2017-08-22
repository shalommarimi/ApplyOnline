using System.Web.Optimization;

namespace ApplyOnline.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/ng").Include(
            //    "~/Scripts/angolar.min.js",
            //    "~/Scripts/angolar-route.min.js",
            //    "~/Scripts/angolar-cookies.min.js",
            //    "~/Scripts/angolar-sanitize.min.js"
            //    ));

            bundles.Add(new ScriptBundle("~/MyScriptsB").Include(
                 "~/MyScripts/jquery.waypoints.min.js",
                 "~/MyScripts/waypoints.js",
                 "~/MyScripts/jquery.cycle2.min.js"

             ));

            bundles.Add(new ScriptBundle("~/ScriptsB").Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/jquery-ui.js",
                "~/Scripts/main.js",
                "~/Scripts/jquery-3.0.0.min.js",
                "~/Scripts/bootstrap.min.js"

                 ));



            bundles.Add(new StyleBundle("~/ContentB").Include(
                   "~/Content/jquery-ui.css"

                 ));

            bundles.Add(new StyleBundle("~/CssB").Include(
                "~/Css/animate.css",
                "~/Css/index.css",
                "~/Css/waypolints.css",
                "~/Css/style.css",
                "~/Css/media.css",
                "~/Css/slider.css",
                "~/Css/side.css",
                "~/Css/partners.css",
                "~/Css/postings.css",
                "~/Css/dashboard.css",
                 "~/Css/login.css"

                ));
            BundleTable.EnableOptimizations = true;

        }


    }
}