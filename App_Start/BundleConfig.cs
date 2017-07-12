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

            bundles.Add(new ScriptBundle("~/MyScripts").Include(
                 "~/MyScripts/jquery.waypoints.min.js",
                 "~/MyScripts/waypoints.js"

             ));

            bundles.Add(new ScriptBundle("~/Scripts").Include(
                "~/Scripts/jquery-1.10.2.js",
                 "~/Scripts/jquery-ui.js",
                  "~/Scripts/main.js",
                  "~/Scripts/jquery-3.0.0.min.js",
                   "~/Scripts/bootstrap.min.js"

                 ));



            bundles.Add(new StyleBundle("~/Content").Include(
                   "~/Content/jquery-ui.css"

                 ));

            bundles.Add(new StyleBundle("~/Css").Include(
                "~/Css/animate.css",
                "~/Css/index.css",
                "~/Css/waypolints.css",
                 "~/Css/style.css"

                ));


        }


    }
}